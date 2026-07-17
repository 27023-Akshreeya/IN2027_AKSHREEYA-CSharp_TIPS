using ContactManager.Models;

namespace ContactManager.Repository
{
    /// <summary>
    /// This is the repo class
    /// </summary>
    public class Repo
    {
        private List<ContactInfo> _contacts = new List<ContactInfo>();

        /// <summary>
        /// This method adds object to the repository.
        /// </summary>
        /// <param name="contact">the argument refers to contact info</param>
        public void Add(ContactInfo contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// this gets the list from repo to other classes
        /// </summary>
        /// <returns>returns the list</returns>
        public List<ContactInfo> GetAllContacts()
        {
            return this._contacts;
        }

        /// <summary>
        /// Remove by name gets the name and removes from the repo
        /// </summary>
        /// <param name="id">gets the corresponding id and removes </param>
        internal void RemoveByname(Guid id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ContactInfo? findId = this._contacts.Find(c => c.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (findId != null)
            {
                this._contacts.Remove(item: findId);
            }
        }

        /// <summary>
        /// Any changes to the repository update model is called
        /// </summary>
        /// <param name="contact">contact refers to the object structure</param>
        /// <param name="id">updates by id</param>
        internal void Update(ContactInfo contact, Guid id)
        {
            ContactInfo? findId = this._contacts.Find(c => c.Id == id);
            if (findId != null)
            {
                findId.Name = contact.Name;
                findId.PhoneNumber = contact.PhoneNumber;
                findId.EmailId = contact.EmailId;
                findId.Notes = contact.Notes;
            }
        }
    }
}