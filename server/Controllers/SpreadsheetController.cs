using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Syncfusion.EJ2.Spreadsheet;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpreadsheetController : ControllerBase
    {
        [HttpPost]
        [Route("OpenFromS3")]
        public async Task<IActionResult> OpenFromS3([FromBody] FileOptions options)
        {
            try
            {
                //Set AWS region and credentials
                var region = RegionEndpoint.USEast1;
                var config = new AmazonS3Config { RegionEndpoint = region };
                var credentials = new BasicAWSCredentials("your-access-key", "your-secret-key");
                //Create an S3 client to interact with AWS
                using (var client = new AmazonS3Client(credentials, config))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        //Get the full file name using input from client
                        string bucketName = "your-bucket-name";
                        string fileName = options.FileName + options.Extension;
                        //Download the file from S3 into memory
                        var response = await client.GetObjectAsync(new GetObjectRequest
                        {
                            BucketName = bucketName,
                            Key = fileName
                        });
                        await response.ResponseStream.CopyToAsync(stream);
                        stream.Position = 0; // Reset stream position for reading
                        //Wrap the stream as a FormFile for processing
                        OpenRequest open = new OpenRequest
                        {
                            File = new FormFile(stream, 0, stream.Length, options.FileName, fileName)
                        };
                        //Convert Excel file to JSON using Workbook.Open
                        var result = Workbook.Open(open);
                        //Return the JSON result to the client
                        return Content(result, "application/json");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors and return a message
                Console.WriteLine($"Error: {ex.Message}");
                return Content("Error occurred while processing the file.");
            }
        }

        // To receive file details from the client.
        public class FileOptions
        {
            public string FileName { get; set; } = string.Empty;
            public string Extension { get; set; } = string.Empty;
        }

        [HttpPost]
        [Route("SaveToS3")]
        public async Task<IActionResult> SaveToS3([FromForm] SaveSettings saveSettings)
        {
            try
            {
                //Convert spreadsheet JSON to Excel file stream
                Stream fileStream = Workbook.Save<Stream>(saveSettings);
                fileStream.Position = 0; // Reset stream for upload
                //Set AWS region and credentials
                var region = RegionEndpoint.USEast1;
                var config = new AmazonS3Config { RegionEndpoint = region };
                var credentials = new BasicAWSCredentials("your-access-key", "your-secret-key");
                //Define S3 bucket and file name
                string bucketName = "your-bucket-name";
                string fileName = saveSettings.FileName + "." + saveSettings.SaveType.ToString().ToLower();
                //Initialize S3 client
                using (var client = new AmazonS3Client(credentials, config))
                {
                    //Use TransferUtility to upload the file stream
                    var fileTransferUtility = new TransferUtility(client);
                    await fileTransferUtility.UploadAsync(fileStream, bucketName, fileName);
                }
                //Return success message
                return Ok("Excel file successfully saved to AWS S3.");
            }
            catch (Exception ex)
            {
                // Handle errors and return message
                return BadRequest("Error saving file to AWS S3: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Open")]
        public IActionResult Open([FromForm] IFormCollection openRequest)
        {
            OpenRequest open = new OpenRequest();
            if (openRequest.Files.Count != 0)
            {
                open.File = openRequest.Files[0];
                if (openRequest.ContainsKey("IsManualCalculationEnabled") && bool.TryParse(openRequest["IsManualCalculationEnabled"].ToString(), out bool flag))
                {
                    open.IsManualCalculationEnabled = flag;
                }
            }
            open.Password = openRequest["Password"];
            if (openRequest["SheetIndex"].Count != 0)
            {
                open.SheetIndex = int.Parse(openRequest["SheetIndex"].ToString());
            }
            open.SheetPassword = openRequest["SheetPassword"];
            return Content(Workbook.Open(open));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromForm] SaveSettings saveSettings)
        {
            return Workbook.Save(saveSettings);
        }
    }
}

