using System.ComponentModel.DataAnnotations;

namespace DAL.Enum
{
    public enum ContractStatus
    {
        [Display(Name = "Unsigned")]
        Unsigned,

        [Display(Name = "Signed")]
        Signed,

        [Display(Name = "Cancelled")]
        Canceled
    }
}