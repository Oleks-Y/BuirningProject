using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurningProject.Models.Blog
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        
        public string ImageId { get; set; }
        
        public bool HasImage()
        {
            return !String.IsNullOrWhiteSpace(ImageId);
        }
    }
}