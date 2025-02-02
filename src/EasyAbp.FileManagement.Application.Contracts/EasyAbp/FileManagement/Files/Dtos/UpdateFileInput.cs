using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.FileManagement.Files.Dtos
{
    [Serializable]
    public class UpdateFileInput : ExtensibleObject
    {
        [Required]
        public string FileName { get; set; }

        public string MimeType { get; set; }
        
        public byte[] Content { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            base.Validate(validationContext);
            
            if (FileName.IsNullOrWhiteSpace())
            {
                yield return new ValidationResult("FileName should not be empty!",
                    new[] {nameof(FileName)});
            }
            
            FileName = FileName.Trim();
        }
    }
}