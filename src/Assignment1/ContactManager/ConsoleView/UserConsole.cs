using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Mail;
using System.Text;
using ContactManager.Models;
using ContactManager.Repository;
using ContactManager.Service;

namespace ContactManager.ConsoleView
{
    /// <summary>
    /// Provides the console-based user interface for interacting with
    /// the Contact Manager application.
    /// </summary>
    public class UserConsole
    {
        private static Repo repo = new Repo();
        private Helper _validate = new Helper();
        private ContactService _contactService = new ContactService(repo);

        /// <summary>
        /// This displays the details of a contact based on the provided ContactInfo object.
        /// </summary>
        /// <param name="id">This points to the searched id</param>
        public static void DisplaySingleContact(ContactInfo id)
        {
            Console.WriteLine($"Name: {id.Name}\nPhone Number: {id.PhoneNumber}\nEmail Address: {id.EmailId}\nNotes: {id.Notes}");
        }

        /// <summary>
        /// Displays a list of contacts in a formatted manner.
        /// </summary>
        /// <param name="sortedContacts">recives the list</param>
        public static void DisplayAllContacts(List<ContactInfo> sortedContacts)
        {
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine($"Name: {contact.Name}\nPhone Number: {contact.PhoneNumber}\nEmail Id: {contact.EmailId}\nNotes: {contact.Notes}");
            }
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
                        var addContact = this.GetContactDetails();
                        if (addContact == null)
                        {
                            continue;
                        }

                        this._contactService.AddContact(addContact);
                        break;
                    case "s":
                        string searchContact = this.GetSearchDetails();
                        this._contactService.SearchContact(searchContact);
                        if (searchContact == null)
                        {
                            continue;
                        }

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
                        if (removeContact == null)
                        {
                            continue;
                        }

                        this._contactService.RemoveContact(removeContact);
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

            bool validChoice = this._validate.IsChoiceValid(userChoice);

            if (validChoice == true)
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
        /// Collects and validates contact details from the user.
        /// </summary>
        /// <returns>A ContactInfo object containing the validated contact details, or null if validation fails.</returns>
        public ContactInfo GetContactDetails()
        {
            Console.Write("Enter your name:");
            var name = Console.ReadLine();

            if (!this._validate.CheckStringValid(name))
            {
                Console.WriteLine("Invalid name. Please try again.");
                return null;
            }

            Console.Write("Enter your Phone number:");
            var inputNumber = Console.ReadLine();

            if (!this._validate.CheckNoValid(inputNumber))
            {
                Console.WriteLine("Invalid phone number. Please try again.");
                return null;
            }

            long phoneNumber = Convert.ToInt64(inputNumber);

            Console.Write("Enter your email address:");
            var emailAddress = Console.ReadLine();

            if (!this._validate.CheckEmailValid(emailAddress))
            {
                Console.WriteLine("Invalid email address. Please try again.");
                return null;
            }

            Console.Write("Enter additional notes:");
            var addNotes = Console.ReadLine();

            if (!this._validate.CheckNotesValid(addNotes))
            {
                Console.WriteLine("Invalid notes. Please try again.");
                return null;
            }

            ContactInfo contact =
                new ContactInfo(name, phoneNumber, emailAddress, addNotes);

            contact.Id = Guid.NewGuid();

            return contact;
        }

        /// <summary>
        /// Allows the user to modify details of an existing contact.
        /// </summary>
        public void GetEditDetails()
        {
            Console.Write("Enter the name of the contact you want to edit:");

            var name = Console.ReadLine();

            ContactInfo contact = this._contactService.GetContactByName(name);
            Guid contactId = this._contactService.GetGuidByName(name);

            if (contact != null)
            {
                Console.Write("Enter the detail you want to edit.\n1.Name\n2.Phone Number\n3.Email address\n4.Notes\nEnter the option number:");

                string contactDetail = Console.ReadLine();
                if (this._validate.IsEditValid(contactDetail) == false)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                int editChoice = Convert.ToInt32(contactDetail);
                if (editChoice == 1)
                {
                    Console.Write("Enter new name:");
                    var editName = Console.ReadLine();

                    if (!this._validate.CheckStringValid(editName))
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

                    if (!this._validate.CheckNoValid(editNumber))
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

                    if (!this._validate.CheckEmailValid(editEmailAddress))
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

                    if (!this._validate.CheckNotesValid(editNotes))
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

            if (!this._validate.CheckStringValid(name))
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
        internal string GetRemoveDetails()
        {
            Console.WriteLine("Enter the name of the contact you want to remove");

            var name = Console.ReadLine();

            bool contactName = this._validate.CheckStringValid(name);

            if (contactName != true)
            {
                Console.WriteLine("Invalid name. Please try again.");
                return null;
            }

            return name;
        }
    }
}