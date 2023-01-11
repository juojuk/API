using System.ComponentModel.DataAnnotations;

namespace dotNET_Baigiamasis.Models.Dto
{
    public class YearRange : RangeAttribute
    {
        public YearRange() : base(typeof(int), "1900", DateTime.Today.Year.ToString()) 
        {
        }
    }
}
