# Syncfusion React Spreadsheet + AWS S3 Integration

This repository demonstrates how to integrate the Syncfusion React Spreadsheet component with AWS S3 cloud storage using a React frontend and an ASP.NET Core Web API backend.

🔗 **Live Demo**

- **React Client Sample (StackBlitz)**: [react-syncfusion-s3-spreadsheet](https://stackblitz.com/edit/react-8ntu1yx9-nepsrag4?file=index.js)
- **Tested files used in the dropdown can be found here**: [Tested Excel files](./client/public/Files/)

📁 **Project Structure**

```
├── client/       # React app with Syncfusion Spreadsheet
└── server/       # ASP.NET Core Web API project
```

✨ **Features**

- Open Excel files directly from AWS S3 into Syncfusion Spreadsheet.
- Edit spreadsheet data in-browser.
- Save changes back to AWS S3 with a single click.
- Dropdown list to select files from S3.

🧩 **Technologies Used**

- React + Syncfusion Spreadsheet
- ASP.NET Core Web API
- AWS SDK for .NET
- AWS S3 for cloud storage

🚀 **Getting Started**

1. **Clone the Repository**

   ```bash
   git clone https://github.com/<your-username>/syncfusion-react-spreadsheet-aws-s3-integration.git
   ```

2. **Setup the Client**

   ```bash
   cd client
   npm install
   npm start
   ```

3. **Setup the Server**

   ```bash
   cd server
   # Open in Visual Studio or VS Code
   # Restore NuGet packages
   ```
   **Update the following in the controller:**

   - AWS Access Key
   - AWS Secret Key
   - S3 Bucket Name
   - Region

4. **Run the Server**
   
   Run the project and test the endpoints directly from the React app

   ```bash
   dotnet run
   ```

📌 **Notes**

- Update the fetch() URLs in the React sample to point to your local backend endpoints for `OpenFromS3` and `SaveToS3`.
- The React sample includes a dropdown list with three predefined Excel files:

   ```javascript
   const fileList = [
      { name: 'Car Sales Report', extension: '.xlsx' },
      { name: 'Shopping Cart', extension: '.xls' },
      { name: 'Price Details', extension: '.csv' },
   ];
   ```
- You can update this list to match the actual Excel files stored in your AWS S3 bucket.
- After selecting a file, click the "Open From S3" button to load the selected Excel file into the Syncfusion Spreadsheet.
- Once you make edits, click the "Save to S3" button to save the changes back to the same file in your S3 bucket.

📄 **License and copyright**

> This is a commercial product and requires a paid license for possession or use. Syncfusion<sup>®</sup> licensed software, including this control, is subject to the terms and conditions of Syncfusion<sup>®</sup> [EULA](https://www.syncfusion.com/eula/es/). To acquire a license for 140+ [JavaScript UI controls](https://www.syncfusion.com/javascript-ui-controls), you can [purchase](https://www.syncfusion.com/sales/products) or [start a free 30-day trial](https://www.syncfusion.com/account/manage-trials/start-trials).

> A [free community license](https://www.syncfusion.com/products/communitylicense) is also available for companies and individuals whose organizations have less than $1 million USD in annual gross revenue and five or fewer developers.

See [LICENSE FILE](https://github.com/syncfusion/ej2-javascript-ui-controls/blob/master/license?utm_source=npm&utm_medium=listing&utm_campaign=javascript-spreadsheet-npm) for more info.

---

Feel free to fork, customize, and contribute to this project!