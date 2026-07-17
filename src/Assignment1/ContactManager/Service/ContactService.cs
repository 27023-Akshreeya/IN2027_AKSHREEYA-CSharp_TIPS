using System;
using System.Collections.Generic;
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
        private Helper _strval = new Helper();

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
            contact.Id = Guid.NewGuid();
            this._repo.Add(contact);
        }

        /// <summary>
        /// remove
        /// </summary>
        /// <param name="name">name</param>
        public void RemoveContact(string? name)
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
            this._repo.Update(contact, guid);
        }

        /// <summary>
        /// search
        /// </summary>
        /// <param name="name">name</param>
        public void SearchContact(string? name)
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
                this._strval.IscontactsEmpty();
                return;
            }

            var sortedContacts = contacts.OrderBy(c => c.Name).ToList();
            UserConsole.Displaylist(sortedContacts);
        }

        /// <summary>
        /// get id
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>returning</returns>
        internal Guid GetGuidByName(string? name)
        {
            List<ContactInfo> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._strval.IscontactsEmpty();
                return Guid.Empty;
            }

            ContactInfo findName = contacts.Find(c => c.Name == name);
            if (findName == null)
            {
                this._strval.IscontactsEmpty();
                return Guid.Empty;
            }

            return findName.Id;
        }

        /*internal void Display()
        {
            List<ContactInfo> contacts = repo.GetAllContacts();
            contacts.ForEach(c => Console.WriteLine($"Name: {c.Name}, \nPhone Number: {c.PhoneNumber}, \nEmail Id: {c.EmailId}, \nNotes: {c.Notes}"));
        }*/

        /// <summary>
        /// contact
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>info</returns>
        internal ContactInfo? GetContactByName(string? name)
        {
            List<ContactInfo> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                this._strval.IscontactsEmpty();
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
               this._strval.IscontactsEmpty();
               return;
            }

            ContactInfo findId = contacts.Find(c => c.Id == id);
            if (findId == null)
            {
                return;
            }

            UserConsole.Display(findId);
        }
    }
}
