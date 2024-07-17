const { BlobServiceClient } = require("@azure/storage-blob");
const fs = require("fs/promises");
const path = require("path");
require("dotenv").config();

async function listBlobs(containerClient) {
  for await (const blob of containerClient.listBlobsFlat()) {
    const tempBlockBlobClient = containerClient.getBlockBlobClient(blob.name);

    console.log(`\n\tname: ${blob.name}\n\tURL: ${tempBlockBlobClient.url}\n`);
  }
}

async function uploadBlob(containerClient, file, blob) {
  await containerClient.getBlockBlobClient(blob).uploadFile(file);
  console.log("Uploaded blob successfully");
}

async function main() {
  try {
    const AZURE_STORAGE_CONNECTION_STRING =
      process.env.AZURE_STORAGE_CONNECTION_STRING;

    if (!AZURE_STORAGE_CONNECTION_STRING) {
      throw Error("Azure Storage Connection string not found");
    }

    const containerClient = BlobServiceClient.fromConnectionString(
      AZURE_STORAGE_CONNECTION_STRING
    ).getContainerClient("gallery-images");

    uploadBlob(
      containerClient,
      path.join(__dirname, "/sample/taxi.png"),
      "taxi"
    );
  } catch (err) {
    console.log(`Error: ${err.message}`);
  }
}

main()
  .then(() => console.log("Done"))
  .catch((ex) => console.log(ex.message));
