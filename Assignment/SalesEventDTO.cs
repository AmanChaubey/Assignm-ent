using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Assignment
{
    [Serializable]
    [DataContract]
    public class SalesEventDTO
    {

        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        /// <value>The identity.</value>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the DiscountId.
        /// </summary>
        /// <value>The DiscountId.</value>
        [DataMember]
        public int DiscountId { get; set; }

        /// <summary>
        /// Gets or sets the DiscountAmount
        /// </summary>
        /// <value>The DiscountAmount</value>
        [DataMember]
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the EventPrice
        /// </summary>
        /// <value>The EventPrice.</value>
        [DataMember]
        public decimal EventPrice { get; set; }

        /// <summary>
        /// Gets or sets the StartDate.
        /// </summary>
        /// <value>The StartDate.</value>
        [DataMember]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the EndDate.
        /// </summary>
        /// <value>The EndDate.</value>
        [DataMember]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>The IsActive.</value>
        [DataMember]
        public bool IsActive { get; set; }
    }
}
