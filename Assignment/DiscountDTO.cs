using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Assignment
{
    [Serializable]
    [DataContract]
    public class DiscountDTO
    {

        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        /// <value>The identity.</value>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Mode.
        /// </summary>
        /// <value>The Mode.</value>
        [DataMember]
        public string Mode { get; set; }

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>The IsActive.</value>
        [DataMember]
        public bool IsActive { get; set; }
    }
}
