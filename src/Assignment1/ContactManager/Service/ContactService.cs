using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManager.ConsoleView;
using ContactManager.Models;
using ContactManager.Repository;

namespace ContactManager.Service
{
    /// <summary>
    /// This class consist of the consoles service
    /// </summary>
    internal class ContactService
    {
        private Repo _repo;
        private Helper _validate = new Helper();

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
        public void AddContact(ContactInfo contact)
        {
            this._repo.AddContactList(contact);
        }

        /// <summary>
        /// remove
        /// </summary>
        /// <param name="name">name</param>
        public void RemoveContact(string name)
        {
            Guid id = this.GetGuidByName(name);
            this._repo.RemoveByname(id);
        }

        /// <summary>
        /// edit
        /// </summary>
        /// <param name="contact">contact</param>
        /// <param name="guid">id</param>
        public void EditContact(ContactInfo contact, Guid guid)
        {
            this._repo.UpdateContactList(contact, guid);
        }

        /// <summary>
        /// search
        /// </summary>
        /// <param name="name">name</param>
        public void SearchContact(string name)
        {
            Guid id = this.GetGuidByName(name);
            this.SearchByName(id);
        }

        /// <summary>
        /// view
        /// </summary>
        internal void ViewContact()
        {
            List<ContactInfo> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._validate.IscontactsEmpty();
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
            List<ContactInfo> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._validate.IscontactsEmpty();
                return Guid.Empty;
            }

            ContactInfo findName = contacts.Find(c => c.Name == name);
            if (findName == null || name == string.Empty)
            {
                this._validate.IscontactsEmpty();
                return Guid.Empty;
            }

            return findName.Id;
        }

        /// <summary>
        /// contact
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>info</returns>
        internal ContactInfo GetContactByName(string name)
        {
            List<ContactInfo> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._validate.IscontactsEmpty();
                return null;
            }

            if (name == string.Empty)
            {
                this._validate.IscontactsEmpty();
                return null;
            }

            ContactInfo findName = contacts.Find(c => c.Name == name);

            return findName;
        }

        /// <summary>
        /// search
        /// </summary>
        /// <param name="id">id</param>
        internal void SearchByName(Guid id)
        {
            List<ContactInfo> contacts = this._repo.GetAllContacts();

            if (contacts.Count == 0)
            {
               this._validate.IscontactsEmpty();
               return;
            }

            ContactInfo findId = contacts.Find(c => c.Id == id);
            if (findId == null)
            {
                return;
            }

            UserConsole.DisplaySingleContact(findId);
        }
    }
}
