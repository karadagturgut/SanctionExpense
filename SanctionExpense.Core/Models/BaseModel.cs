using System.ComponentModel.DataAnnotations;


namespace SanctionExpense.Core.Models
{

    public abstract class BaseModel
    {
        // temel sınıf olduğundan absract olarak atandı. her defasında yeni bir örnek oluşturmamak lazım.
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
