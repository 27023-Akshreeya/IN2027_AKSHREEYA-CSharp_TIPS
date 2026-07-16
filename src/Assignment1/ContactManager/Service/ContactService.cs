using System;
using System.Collections.Generic;
using System.Text;
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
            this._repo = _repo;
        }
        /// <summary>
        /// add contact
        /// </summary>
        /// <param name="contact">add</param>
        public void AddContact(ContactInfo contact)
        {
            contact.Id = Guid.NewGuid();
            _repo.Add(contact);
        }
        /// <summary>
        /// remove
        /// </summary>
        /// <param name="name">name</param>
        public void RemoveContact(string? name)
        {
            Guid id = GetGuidByName(name);
            _repo.RemoveByname(id);
        }
        /// <summary>
        /// edit 
        /// </summary>
        /// <param name="contact">contact</param>
        /// <param name="guid">id</param>
        public void EditContact(ContactInfo contact, Guid guid)
        {
            _repo.Update(contact, guid);
        }
        /// <summary>
        /// search
        /// </summary>
        /// <param name="name">name</param>
        public void SearchContact(string? name)
        {
            Guid id = GetGuidByName(name);
            SearchByName(id);
        }
        /// <summary>
        /// view
        /// </summary>
        internal void ViewContact()
        {
            List<ContactInfo> contacts = _repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }
            var sortedContacts = contacts.OrderBy(c => c.Name).ToList();
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine($"Name: {contact.Name}, \nPhone Number: {contact.PhoneNumber}, \nEmail Id: {contact.EmailId}, \nNotes: {contact.Notes}");
            }
        }
        /// <summary>
        /// get id
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>returning</returns>
        internal Guid GetGuidByName(string? name)
        {
            List<ContactInfo> contacts = _repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return Guid.Empty;
            }
            ContactInfo findName = contacts.Find(c => c.Name == name);
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
        internal ContactInfo GetContactByName(string? name)
        {
            List<ContactInfo> contacts = _repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
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
            List<ContactInfo> contacts = _repo.GetAllContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            ContactInfo findId = contacts.Find(c => c.Id == id);
            Console.WriteLine($"Name: {findId.Name}\n");
            Console.WriteLine($"Name: {findId.PhoneNumber}\n");
            Console.WriteLine($"Name: {findId.EmailId}\n");
            Console.WriteLine($"Name: {findId.Notes}");
        }
    }
}
