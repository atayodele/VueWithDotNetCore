using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VueCrudSolution.Data.Models
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class BaseEntity<T> : IEntity<T>
    {
        public virtual T Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        private List<ValidationError> _validationErrors = new List<ValidationError>();
        [NotMapped]
        public List<ValidationError> ValidationErrors
        {
            get
            {
                if (_validationErrors == null)
                { _validationErrors = new List<ValidationError>(); }
                return _validationErrors;
            }
            set { _validationErrors = value; }
        }

        [NotMapped]
        public Boolean HasErrors
        {
            get
            {
                return ValidationErrors.Count > 0;
            }
        }


        public virtual List<ValidationError> Validate()
        {
            return _validationErrors;
        }
    }
    public abstract class BaseEntity : BaseEntity<Guid>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid CreatedBy_Id { get; set; }
        [ForeignKey("CreatedBy_Id")]
        public ApplicationIdentityUser CreatedBy { get; set; }
        public Guid? ModifiedBy_Id { get; set; }
        [ForeignKey("ModifiedBy_Id")]
        public ApplicationIdentityUser ModifiedBy { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
