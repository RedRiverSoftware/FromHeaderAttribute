using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FromHeaderAttribute.Sample.Models
{
    public class PenguinProofHeaders
    {
        [RegularExpression("Penguin", ErrorMessage = "Must be identified as a penguin")]
        public string UserAgent { get; set; }

        [Required(ErrorMessage = "Your penguin code name is required")]
        public string XPenguinCodeName { get; set; }
    }
}