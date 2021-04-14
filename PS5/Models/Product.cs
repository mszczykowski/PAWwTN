using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace PS5.Models
{
    public class Product
    {
        [JsonIgnore]
        public int Id { get; set; }
        [NotMapped, JsonPropertyName("id")]
        public string _Id 
        { 
            get => Id.ToString();
            set
            {
                Id = StringToHash(value); 
            } 
        }
        [MaxLength(100)]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        private int StringToHash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
            int numericValue = BitConverter.ToInt32(hashed, 0);
            return numericValue;
        }
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
