using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Mail;
using System.Text;
using ContactManager.Helper;
using ContactManager.Models;
using ContactManager.Repository;
using ContactManager.Service;

namespace ContactManager.View
{
    /// <summary>
    /// Provides the console-based user interface for interacting with
    /// the Contact Manager application.
    /// </summary>
    public class UserConsole
    {
        private static Repo repo = new Repo();
        private Validator _helper = new Validator();
        private ContactService _contactService = new ContactService(repo);

        /// <summary>
        /// This displays the details of a contact based on the provided Contact object.
        /// </summary>
        /// <param name="id">This points to the searched id</param>
        public static void DisplaySingleContact(Contact id)
        {
            Console.WriteLine($"\nName: {id.Name}\nPhone Number: {id.PhoneNumber}\nEmail Address: {id.EmailId}\nNotes: {id.Notes}");
        }

        /// <summary>
        /// Displays a list of contacts in a formatted manner.
        /// </summary>
        /// <param name="sortedContacts">recives the list</param>
        public static void DisplayAllContacts(List<Contact> sortedContacts)
        {
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine($"\nName: {contact.Name}\nPhone Number: {contact.PhoneNumber}\nEmail Id: {contact.EmailId}\nNotes: {contact.Notes}");
            }
        }

        /// <summary>
        /// This method lets user know if an operation is succussfully completed
        /// </summary>
        /// <param name="operationPerformed">the operation that is performed</param>
        public static void Wrapper(string operationPerformed)
        {
            Console.WriteLine($"\nSuccessfully {operationPerformed}!\n");
        }

        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        public void Menu()
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("MENU");
                Console.WriteLine("[A]dd contact");
                Console.WriteLine("[S]earch contact");
                Console.WriteLine("[V]iew all contact");
                Console.WriteLine("[E]dit contact");
                Console.WriteLine("[R]emove contact");
                Console.WriteLine("[C]lose contact");
                Console.WriteLine("------------------");

                string userChoice = this.GetUserChoice();
                if (userChoice == null)
                {
                    continue;
                }

                switch (userChoice.ToLower())
                {
                    case "a":
                        var newContact = this.GetContactDetails();
                        if (newContact is null)
                        {
                            continue;
                        }

                        this._contactService.AddNewContact(newContact);
                        break;
                    case "s":
                        string searchContact = this.GetSearchDetails();
                        if (searchContact is null)
                        {
                            continue;
                        }

                        this._contactService.SearchContact(searchContact);
                        Console.WriteLine();
                        break;
                    case "v":
                        this.GetViewDetails();
                        Console.WriteLine();
                        break;
                    case "e":
                        this.GetEditDetails();
                        Console.WriteLine();
                        break;
                    case "r":
                        var removeContact = this.GetRemoveDetails();
                        if (removeContact == 0)
                        {
                            continue;
                        }

                        this._contactService.RemoveContactByPhoneNumber(removeContact);
                        Console.WriteLine();
                        break;
                    case "c":
                        flag = false;
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Reads and validates the user's menu choice.
        /// </summary>
        /// <returns>
        /// The validated user choice if valid; otherwise, an error message.
        /// </returns>
        public string GetUserChoice()
        {
            Console.Write("Enter a choice:");
            var userChoice = Console.ReadLine();

            bool isValidChoice = this._helper.IsChoiceValid(userChoice);

            if (isValidChoice == true)
            {
                return userChoice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                return null;
            }
        }

        /// <summary>
        /// Gets and validates contact details from the user.
        /// </summary>
        /// <returns>A Contact object containing the validated contact details, or null if validation fails.</returns>
        public Contact GetContactDetails()
        {
            Console.Write("Enter your name:");
            var name = Console.ReadLine();

            if (!this._helper.CheckStringValid(name))
            {
                Console.WriteLine("Invalid name. Please try again.");
                return null;
            }

            Console.Write("Enter your Phone number:");
            var inputPhoneNumber = Console.ReadLine();

            if (!this._helper.CheckValidPhoneNumber(inputPhoneNumber))
            {
                Console.WriteLine("Invalid phone number. Please try again.");
                return null;
            }

            long phoneNumber = Convert.ToInt64(inputPhoneNumber);

            Console.Write("Enter your email address:");
            var emailAddress = Console.ReadLine();

            if (!this._helper.CheckEmailValid(emailAddress))
            {
                Console.WriteLine("Invalid email address. Please try again.");
                return null;
            }

            Console.Write("Enter additional notes:");
            var addNotes = Console.ReadLine();

            if (!this._helper.CheckNotesValid(addNotes))
            {
                Console.WriteLine("Invalid notes. Please try again.");
                return null;
            }

            Contact contact =
                new Contact(name, phoneNumber, emailAddress, addNotes);

            contact.Id = Guid.NewGuid();

            return contact;
        }

        /// <summary>
        /// Gets contact details to modify details of an existing contact.
        /// </summary>
        public void GetEditDetails()
        {
            Console.Write("Enter the name of the contact you want to edit:");

            var name = Console.ReadLine();

            Contact contact = this._contactService.GetContactByName(name);
            Guid contactId = this._contactService.GetGuidByName(name);

            if (contact != null)
            {
                Console.Write("Enter the detail you want to edit.\n1.Name\n2.Phone Number\n3.Email address\n4.Notes\nEnter the option number:");

                string contactDetail = Console.ReadLine();
                if (this._helper.IsValidInteger(contactDetail) == false)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                int editChoice = Convert.ToInt32(contactDetail);
                if (editChoice == 1)
                {
                    Console.Write("Enter new name:");
                    var editName = Console.ReadLine();

                    if (!this._helper.CheckStringValid(editName))
                    {
                        Console.WriteLine("Invalid name try again");
                        return;
                    }

                    contact.Name = editName;
                    this._contactService.EditContact(contact, contactId);
                }
                else if (editChoice == 2)
                {
                    Console.Write("Enter new phone number:");

                    var editNumber = Console.ReadLine();

                    if (!this._helper.CheckValidPhoneNumber(editNumber))
                    {
                        Console.WriteLine("Invalid phone number try again");
                        return;
                    }

                    long editPhoneNumber = Convert.ToInt64(editNumber);
                    contact.PhoneNumber = editPhoneNumber;

                    this._contactService.EditContact(contact, contactId);
                }
                else if (editChoice == 3)
                {
                    Console.Write("Enter new email address:");

                    var editEmailAddress = Console.ReadLine();

                    if (!this._helper.CheckEmailValid(editEmailAddress))
                    {
                        Console.WriteLine("Invalid email address try again");
                        return;
                    }

                    contact.EmailId = editEmailAddress;
                    this._contactService.EditContact(contact, contactId);
                }
                else if (editChoice == 4)
                {
                    Console.Write("Enter new notes:");

                    var editNotes = Console.ReadLine();

                    if (!this._helper.CheckNotesValid(editNotes))
                    {
                        Console.WriteLine("Invalid notes try again");
                        return;
                    }

                    contact.Notes = editNotes;
                    this._contactService.EditContact(contact, contactId);
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }

                Console.WriteLine("Contact updated successfully");
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        /// <summary>
        /// Displays all contacts stored in the system.
        /// </summary>
        internal void GetViewDetails()
        {
            this._contactService.ViewContact();
        }

        /// <summary>
        /// This method prompts the user to enter the name of a contact they wish to search for and validates the input.
        /// </summary>
        /// <returns>it returns string</returns>
        internal string GetSearchDetails()
        {
            Console.WriteLine("Enter the name of the contact you want to search");

            var name = Console.ReadLine();

            if (!this._helper.CheckStringValid(name))
            {
                Console.WriteLine("Invalid name. Please try again.");
                return null;
            }

            return name;
        }

        /// <summary>
        /// This method prompts the user to enter the name of a contact they wish to remove and validates the input.
        /// </summary>
        /// <returns>it returns a string of name</returns>
        internal long GetRemoveDetails()
        {
            Console.Write("Enter the phone number of the contact you want to remove:");

            var inputPhoneNumber = Console.ReadLine();

            bool contactPhoneNumber = this._helper.CheckValidPhoneNumber(inputPhoneNumber);

            if (contactPhoneNumber != true)
            {
                Console.WriteLine("Invalid PhoneNumber. Please try again.");
                return 0;
            }

            long phoneNumber = Convert.ToInt64(inputPhoneNumber);
            return phoneNumber;
        }
    }
}