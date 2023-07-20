using Domain.Models.Ship;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Ship : BaseEntity
    {
        private const string CODE_PATTERN = @"^[a-zA-Z]{4}-[0-9]{4}-[a-zA-Z]{1}[0-9]{1}$";

        public Ship()
        {
        }

        public Ship(ShipAddRequest model)
        {
            Name = model.Name;
            Length = model.Length;
            Width = model.Width;
            Code = model.Code;

            Validate();
        }

        public Ship(ShipUpdateRequest model)
        {
            Id = model.Id;
            Name = model.Name;
            Length = model.Length;
            Width = model.Width;
            Code = model.Code;

            Validate();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                Errors.Add("Name is required");

            if (string.IsNullOrEmpty(Code))
                Errors.Add("Code is required");
            else if (!Regex.IsMatch(Code, CODE_PATTERN, RegexOptions.None))
                Errors.Add("Code invalid. Use the following pattern: 'AAAA-1111-A1'");

            if (Length <= 0)
                Errors.Add("Length must be greater than 0");

            if (Width <= 0)
                Errors.Add("Width must be greater than 0");
        }
    }
}
