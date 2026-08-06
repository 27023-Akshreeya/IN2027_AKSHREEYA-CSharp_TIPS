using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// /// <summary>
        /// construct of the class
        /// </summary>
        /// <param name="repo">argument pass</param>
        /// <returns>The joined names.</returns>
        internal ContactService(Repo repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Adds the specified contact to the repository.
        /// </summary>
        /// <param name="contact">The contact to add.</param>
        /// <returns>true if the contact was added successfully; otherwise, false.</returns>
        internal bool AddNewContact(Contact contact)
        {
            if (contact != null)
            {
                this._repo.AddContact(contact);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the specific contact to the repository.
        /// </summary>
        /// <param name="phoneNumber">The contact to remove.</param>
        /// <returns>true if the contact was removed successfully; otherwise, false.</returns>
        internal bool RemoveContactByPhoneNumber(long phoneNumber)
        {
            Guid id = this.GetGuidByPhoneNumber(phoneNumber);
            if (id != Guid.Empty)
            {
                this._repo.RemoveContact(id);
                return true;
            }

            ContactViewer.DisplayIsContactsEmpty();
            return false;
        }

        /// <summary>
        /// Updates a contact with the specified information.
        /// </summary>
        /// <param name="contact">The contact containing updated details.</param>
        /// <param name="guid">The unique identifier of the contact to update.</param>
        /// <returns>true if the contact was updated successfully; otherwise, false.</returns>
        internal bool EditExisitingContact(Contact contact, Guid guid)
        {
            if (contact != null || guid != Guid.Empty)
            {
                this._repo.UpdateContact(contact, guid);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Searches contact by name or phone number
        /// </summary>
        /// <param name="searchContactInput">phone number or name</param>
        /// <param name="usersSearchChoice">choice selected by the user</param>
        /// <returns>true if operation executed as intended , otherwise false</returns>
        internal bool SearchContact(string searchContactInput, string usersSearchChoice)
        {
            if (usersSearchChoice.Equals("1"))
            {
                return this.SearchContactByname(searchContactInput);
            }
            else if (usersSearchChoice.Equals("2"))
            {
                return this.SearchContactByPhoneNumber(long.Parse(searchContactInput));
            }

            return false;
        }

        /// <summary>
        /// view
        /// </summary>
        internal void ViewAllContacts()
        {
            List<Contact> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                ContactViewer.DisplayIsContactsEmpty();
                return;
            }

            var sortedContacts = contacts.OrderBy(c => c.Name).ToList();
            ContactViewer.DisplayContact(sortedContacts);
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
                ContactViewer.DisplayIsContactsEmpty();
                return Guid.Empty;
            }

            var findName = contacts.Find(c => c.Name == name);
            if (findName == null || name == string.Empty)
            {
                ContactViewer.DisplayIsContactsEmpty();
                return Guid.Empty;
            }

            return findName.Id;
        }

        /// <summary>
        /// This Functions checks if the list of contacts is empty
        /// </summary>
        /// <returns>true if the contacts is empty; otherwise, false</returns>
        internal bool CheckIfContactsIsEmpty()
        {
            List<Contact> contacts = this._repo.GetAllContacts();
            if (contacts.Count == 0)
            {
                ContactViewer.DisplayIsContactsEmpty();
                return true;
            }

            return false;
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
                return Guid.Empty;
            }

            var findphoneNumber = contacts.Find(c => c.PhoneNumber == phoneNumber);
            if (findphoneNumber == null)
            {
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
            if (this.CheckIfContactsIsEmpty())
            {
                return null;
            }

            if (name.Equals(string.Empty))
            {
                ContactViewer.DisplayIsContactsEmpty();
                return null;
            }

            return contacts.Find(c => c.Name == name);
        }

        /// <summary>
        /// This method lists all the similar contacts.
        /// </summary>
        /// <param name="name">similar names will be searched</param>
        /// <returns>true if search operation is executed correctly , otherwise false</returns>
        internal bool SearchContactByname(string name)
        {
            var contacts = this._repo.GetAllContacts();
            if (this.CheckIfContactsIsEmpty())
            {
                return false;
            }

            var matchingContacts = contacts.Where(c => c.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matchingContacts.Count.Equals(0))
            {
                return false;
            }

            ContactViewer.DisplayContact(matchingContacts);
            return true;
        }

        /// <summary>
        /// Searches contact by phone Number
        /// </summary>
        /// <param name="phoneNumber">phone number to search</param>
        /// <returns>true if search operation is executed correctly , otherwise false</returns>
        internal bool SearchContactByPhoneNumber(long phoneNumber)
        {
            var contacts = this._repo.GetAllContacts();
            if (this.CheckIfContactsIsEmpty())
            {
                return false;
            }

            var id = this.GetGuidByPhoneNumber(phoneNumber);
            var matchingContact = contacts.Find(c => c.Id == id);
            if (matchingContact == null)
            {
                return false;
            }

            ContactViewer.DisplaySingleContact(matchingContact);
            return true;
        }
    }
}
