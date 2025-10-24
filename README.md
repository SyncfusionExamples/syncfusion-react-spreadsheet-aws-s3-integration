# Syncfusion React Spreadsheet + AWS S3 Integration

This repository demonstrates how to integrate the Syncfusion React Spreadsheet component with AWS S3 cloud storage using a React frontend and an ASP.NET Core Web API backend.

🔗 **Live Demo**

- **React Client Sample (StackBlitz)**: [https://stackblitz.com/edit/react-syncfusion-s3-spreadsheet](https://stackblitz.com/edit/react-syncfusion-s3-spreadsheet)
- **Tested Files**: [https://your-s3-or-github-link.com](https://your-s3-or-github-link.com)

📁 **Project Structure**

```
├── client/       # React app with Syncfusion Spreadsheet
├── server/       # ASP.NET Core Web API project
└── README.md     # Project documentation
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

   **Update AWS Credentials**

   In `appsettings.json` or directly in the controller:

   ```json
   {
     "AWS": {
       "AccessKey": "<your-access-key>",
       "SecretKey": "<your-secret-key>",
       "BucketName": "<your-bucket-name>",
       "Region": "us-east-1"
     }
   }
   ```

4. **Run the Server**

   ```bash
   dotnet run
   ```

📌 **Notes**

The dropdown in the React app uses the following sample list:

```javascript
const fileList = [
  { name: 'Car Sales Report', extension: '.xlsx' },
  { name: 'Shopping Cart', extension: '.xls' },
  { name: 'Price Details', extension: '.csv' },
];
```

Update this list to match your actual S3 files.

📄 **License**

This project is licensed under the MIT License.

---

Feel free to fork, customize, and contribute to this project!