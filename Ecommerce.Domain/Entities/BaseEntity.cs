using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid(); 
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow; 
        public DateTime? UpdatedAt { get; private set; } 

        protected BaseEntity() { }

        /// <summary>
        /// Updates the last modified timestamp for the entity.
        /// </summary>
        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the entities are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is not BaseEntity otherEntity) return false;
            return Id == otherEntity.Id;
        }

        /// <summary>
        /// Returns the hash code for the entity, based on its ID.
        /// </summary>
        /// <returns>Hash code for the entity.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of the entity.
        /// </summary>
        /// <returns>A string representing the entity.</returns>
        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}, CreatedAt={CreatedAt}, UpdatedAt={UpdatedAt}]";
        }
    }
}
