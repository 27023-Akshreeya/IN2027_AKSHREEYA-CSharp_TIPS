using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManager.Helper;
using ContactManager.Models;
using ContactManager.Repository;
using ContactManager.View;

namespace ContactManager.Service
{
    /// <summary>
    /// This class consist of the consoles service
    /// </summary>
    internal class ContactService
    {
        private Repo _repo;
        private Validator _helper = new Validator();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// /// <summary>
        /// construct of the class
        /// </summary>
        /// <param name="repo">argument pass</param>
        /// <returns>The joined names.</returns>
        public ContactService(Repo repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// add contact
        /// </summary>
        /// <param name="contact">add</param>
        public void AddNewContact(Contact contact)
        {
            this._repo.AddContact(contact);
        }

        /// <summary>
        /// remove
        /// </summary>
        /// <param name="phoneNumber">name</param>
        public void RemoveContactByPhoneNumber(long phoneNumber)
        {
            Guid id = this.GetGuidByPhoneNumber(phoneNumber);
            this._repo.RemoveContact(id);
        }

        /// <summary>
        /// edit
        /// </summary>
        /// <param name="contact">contact</param>
        /// <param name="guid">id</param>
        public void EditContact(Contact contact, Guid guid)
        {
            this._repo.UpdateContact(contact, guid);
        }

        /// <summary>
        /// search
        /// </summary>
        /// <param name="name">name</param>
        public void SearchContact(string name)
        {
            this.SearchContactByname(name);
        }

        /// <summary>
        /// view
        /// </summary>
        internal void ViewContact()
        {
            List<Contact> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._helper.IscontactsEmpty();
                return;
            }

            var sortedContacts = contacts.OrderBy(c => c.Name).ToList();
            UserConsole.DisplayAllContacts(sortedContacts);
        }

        /// <summary>
        /// get id
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>returning</returns>
        internal Guid GetGuidByName(string name)
        {
            List<Contact> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._helper.IscontactsEmpty();
                return Guid.Empty;
            }

            Contact findName = contacts.Find(c => c.Name == name);
            if (findName == null || name == string.Empty)
            {
                this._helper.IscontactsEmpty();
                return Guid.Empty;
            }

            return findName.Id;
        }

        /// <summary>
        /// Retrieves the unique identifier of the contact associated with the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to search for in the contact list.</param>
        /// <returns>The unique identifier of the contact if found; otherwise, Guid.Empty.</returns>
        internal Guid GetGuidByPhoneNumber(long phoneNumber)
        {
            List<Contact> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._helper.IscontactsEmpty();
                return Guid.Empty;
            }

            Contact findphoneNumber = contacts.Find(c => c.PhoneNumber == phoneNumber);
            if (findphoneNumber == null)
            {
                this._helper.IscontactsEmpty();
                return Guid.Empty;
            }

            return findphoneNumber.Id;
        }

        /// <summary>
        /// contact
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>info</returns>
        internal Contact GetContactByName(string name)
        {
            List<Contact> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._helper.IscontactsEmpty();
                return null;
            }

            if (name == string.Empty)
            {
                this._helper.IscontactsEmpty();
                return null;
            }

            Contact findName = contacts.Find(c => c.Name == name);

            return findName;
        }

        /// <summary>
        /// This method lists all the similar contacts.
        /// </summary>
        /// <param name="name">name to seach</param>
        internal void SearchContactByname(string name)
        {
            var contacts = this._repo.GetAllContacts();

            if (contacts.Count == 0)
            {
               this._helper.IscontactsEmpty();
               return;
            }

            var matchingContacts = contacts.Where(c => c.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matchingContacts.Count == 0)
            {
                return;
            }

            UserConsole.DisplayAllContacts(matchingContacts);
        }
    }
}
