using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ContactManager.Models;
using ContactManager.View;

namespace ContactManager.Repository
{
    /// <summary>
    /// This is the repo class
    /// </summary>
    public class Repo
    {
        private List<Contact> _contacts = new List<Contact>();

        /// <summary>
        /// This method adds object to the repository
        /// </summary>
        /// <param name="contact">This refers to the contacts</param>
        /// <returns>true if the contact was successfully Added; otherwise, false.</returns>
        public bool AddContact(Contact contact)
        {
            this._contacts.Add(contact);
            return true;
        }

        /// <summary>
        /// this gets the list from repo to other classes
        /// </summary>
        /// <returns>returns the list</returns>
        public List<Contact> GetAllContacts()
        {
            return this._contacts;
        }

        /// <summary>
        /// Removes the contact with the specified unique identifier from the collection.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to remove.</param>
        /// <returns>true if the contact was successfully removed; otherwise, false.</returns>
        internal bool RemoveContact(Guid id)
        {
            var existingContact = this._contacts.Find(c => c.Id == id);
            if (existingContact == null)
            {
                return false;
            }

            this._contacts.Remove(existingContact);
            return true;
        }

        /// <summary>
        /// Updates the details of an existing contact identified by the specified unique identifier.
        /// </summary>
        /// <param name="contact">The contact information used to update the existing contact.</param>
        /// <param name="id">The unique identifier of the contact to update.</param>
        /// <returns>true if the contact was updated successfully; otherwise, false.</returns>
        internal bool UpdateContact(Contact contact, Guid id)
        {
            Contact existingContact = this._contacts.Find(c => c.Id == id);
            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.EmailId = contact.EmailId;
            existingContact.Notes = contact.Notes;
            return true;
        }
    }
}