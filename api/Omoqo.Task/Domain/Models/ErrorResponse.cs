using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ErrorResponse
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ErrorResponse()
        {
        }

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }

        public ErrorResponse(Exception exception)
        {
            Errors = new List<string> { exception.Message };
        }
    }
}
