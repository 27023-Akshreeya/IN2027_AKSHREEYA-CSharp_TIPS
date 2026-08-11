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
        public void AddContact(Contact contact)
        {
            this._contacts.Add(contact);
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
        public void RemoveContact(Guid id)
        {
            var existingContact = this._contacts.Find(c => c.Id == id);
            if (existingContact != null)
            {
                this._contacts.Remove(existingContact);
            }
        }

        /// <summary>
        /// Updates the details of an existing contact identified by the specified unique identifier.
        /// </summary>
        /// <param name="contact">The contact information used to update the existing contact.</param>
        /// <param name="id">The unique identifier of the contact to update.</param>
        public void UpdateContact(Contact contact, Guid id)
        {
            var existingContact = this._contacts.Find(c => c.Id == id);
            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.EmailId = contact.EmailId;
                existingContact.Notes = contact.Notes;
            }
        }
    }
}