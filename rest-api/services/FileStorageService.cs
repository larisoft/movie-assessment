using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using rest_api.models;

namespace rest_api.services
{
    public class FileStorageService
    {
        private readonly string filePath;

        public FileStorageService(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Movie> ReadMoviesFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Movie>>(json);
                }
            }
            catch (Exception ex)
            {
                // Handle file read errors as needed
            }

            return new List<Movie>();
        }

        public void WriteMoviesToFile(List<Movie> movies)
        {
            try
            {
                string json = JsonConvert.SerializeObject(movies);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                // Handle file write errors as needed
            }
        }
    }
}
