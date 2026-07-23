using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Repository;

namespace ContactManager.Models
{
    /// <summary>
    /// Represents a contact and stores personal information such as
    /// name, phone number, email address, and notes.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the contact.
        /// </param>
        /// <param name="phoneNumber">
        /// The phone number of the contact.
        /// </param>
        /// <param name="emailId">
        /// The email address of the contact.
        /// </param>
        /// <param name="notes">
        /// Additional notes associated with the contact.
        /// </param>
        public Contact(string name, long phoneNumber, string emailId, string notes)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.EmailId = emailId;
            this.Notes = notes;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the contact.
        /// </summary>
        /// <value>
        /// A unique identifier used to distinguish the contact.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>
        /// The contact's name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        /// <value>
        /// The contact's phone number.
        /// </value>
        public long PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address of the contact.
        /// </summary>
        /// <value>
        /// The contact's email address.
        /// </value>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets additional notes about the contact.
        /// </summary>
        /// <value>
        /// Additional information related to the contact.
        /// </value>
        public string Notes { get; set; }
    }
}