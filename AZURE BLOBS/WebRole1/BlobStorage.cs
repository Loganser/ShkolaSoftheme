using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace WebRole1
{
    public class BlobStorage
    {

        public CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("asignarprojectstorage"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("asignar-user-photos");
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return blobContainer;
        }
        
    }
}