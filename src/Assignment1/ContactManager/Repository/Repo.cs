using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ContactManager.Repository
{
    /// <summary>
    /// This is the repo class
    /// </summary>
    public class Repo
    {
        private List<ContactInfo> _contacts = new List<ContactInfo>();
        /// <summary>
        /// This method adds object to the repository 
        /// </summary>
        /// <param name="contact">the argument refers to contact info</param>
        public void Add(ContactInfo contact)
        {
            _contacts.Add(contact);
        }
        /// <summary>
        /// this gets the list from repo to other classes
        /// </summary>
        /// <returns>returns the list</returns>
        public List<ContactInfo> GetAllContacts()
        {
            return _contacts;
        }
        /// <summary>
        /// Remove by name gets the name and removes from the repo
        /// </summary>
        /// <param name="id">gets the corresponding id and removes </param>
        internal void RemoveByname(Guid id)
        {
            ContactInfo findId = _contacts.Find(c => c.Id == id);
            _contacts.Remove(findId);
        }
        /// <summary>
        /// Any changes to the repository update model is called
        /// </summary>
        /// <param name="contact">contact refers to the object structure</param>
        /// <param name="id">updates by id</param>
        internal void Update(ContactInfo contact, Guid id)
        {
            if (id != null)
            {
                ContactInfo findId = _contacts.Find(c => c.Id == id);
                findId.Name = contact.Name;
                findId.PhoneNumber = contact.PhoneNumber;
                findId.EmailId = contact.EmailId;
                findId.Notes = contact.Notes;
            }
        }
    }
}

