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
        /// <param name="contact">the argument refers to contact info</param>
        public void AddContact(Contact contact)
        {
            this._contacts.Add(contact);
            UserConsole.Wrapper("added new contact!");
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
        /// Remove by name gets the name and removes from the repo
        /// </summary>
        /// <param name="id">gets the corresponding id and removes </param>
        internal void RemoveContact(Guid id)
        {
            Contact existingContact = this._contacts.Find(c => c.Id == id);
            this._contacts.Remove(existingContact);
            UserConsole.Wrapper("removed contact!");
        }

        /// <summary>
        /// Any changes to the repository update model is called
        /// </summary>
        /// <param name="contact">contact refers to the object structure</param>
        /// <param name="id">updates by id</param>
        internal void UpdateContact(Contact contact, Guid id)
        {
            Contact existingContact = this._contacts.Find(c => c.Id == id);
            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.EmailId = contact.EmailId;
            existingContact.Notes = contact.Notes;
            UserConsole.Wrapper("updated contact!");
        }
    }
}