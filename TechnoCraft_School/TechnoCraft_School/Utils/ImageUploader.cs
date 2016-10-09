using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TechnoCraft_School.Utils
{
    public class ImageUploader : IDisposable
    {
        public void Dispose()
        {
           
        }

        public string UploadImage(HttpPostedFileBase imageToUpload, string fileName, string location)
        {
            try
            {
                if (imageToUpload != null && !string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(location))
                {
                    if (imageToUpload.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 3; //3 MB
                        string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };
                        string fileExtension = imageToUpload.FileName.Substring(imageToUpload.FileName.LastIndexOf('.'));
                        if (!AllowedFileExtensions.Contains(fileExtension))
                        {
                            throw new ArgumentException(fileExtension + " is not allowed extension of file");
                        }
                        else if (imageToUpload.ContentLength > MaxContentLength)
                        {
                            throw new ArgumentException("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                        }

                        fileName = Path.Combine(fileName + fileExtension);
                        var path = Path.Combine(location, fileName);
                        imageToUpload.SaveAs(path);
                    }
                    else
                    {
                        throw new Exception("No image content");
                    }
                    return fileName;
                }
                else
                {
                    throw new ArgumentNullException("One of the passed argument is null");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteImage(string location)
        {
            try
            {
                File.Delete(location);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}