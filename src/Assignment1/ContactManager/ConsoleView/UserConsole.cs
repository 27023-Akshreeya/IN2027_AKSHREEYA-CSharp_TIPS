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
        private Helper _strval = new Helper();
        private ContactService _con = new ContactService(repo);

        /// <summary>
        /// This displays the details of a contact based on the provided ContactInfo object.
        /// </summary>
        /// <param name="id">This points to the searched id</param>
        public static void Display(ContactInfo id)
        {
            Console.WriteLine($"Name: {id.Name}\n");
            Console.WriteLine($"Name: {id.PhoneNumber}\n");
            Console.WriteLine($"Name: {id.EmailId}\n");
            Console.WriteLine($"Name: {id.Notes}");
        }

        /// <summary>
        /// Displays a list of contacts in a formatted manner.
        /// </summary>
        /// <param name="sortedContacts">recives the list</param>
        public static void Displaylist(List<ContactInfo> sortedContacts)
        {
            foreach (var contact in sortedContacts)
            {
                Console.WriteLine($"Name: {contact.Name}, \nPhone Number: {contact.PhoneNumber}, \nEmail Id: {contact.EmailId}, \nNotes: {contact.Notes}");
            }
        }

        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        public void Menu()
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
        }

        /// <summary>
        /// Reads and validates the user's menu choice.
        /// </summary>
        /// <returns>
        /// The validated user choice if valid; otherwise, an error message.
        /// </returns>
        public string GetChoice()
        {
            Console.Write("Enter a choice:");
            string? userChoice = Console.ReadLine();

            string? outChoice = this._strval.IsChoiceValid(userChoice);

            if (outChoice == null)
            {
                return userChoice;
            }

            return outChoice;
        }

        /// <summary>
        /// Collects contact information from the user and adds a new contact.
        /// </summary>
        public void GetAdd()
        {
            Console.Write("Enter your name:");
            string? name = Console.ReadLine();

            string? resName = this._strval.CheckStrValidity(name);

            if (resName != null)
            {
                Console.WriteLine(resName);
                return;
            }

            Console.Write("Enter your Phone number:");
            string? phoneNumStr = Console.ReadLine();

            string? resNum = this._strval.CheckNumValidity(phoneNumStr);

            if (resNum != null)
            {
                Console.WriteLine(resNum);
                return;
            }

            long phoneNumber = Convert.ToInt64(phoneNumStr);

            Console.Write("Enter your email address:");
            string? emailAddress = Console.ReadLine();

            string? resEA = this._strval.CheckEmailValidity(emailAddress);

            if (resEA != null)
            {
                Console.WriteLine(resEA);
                return;
            }

            Console.Write("Enter additional notes:");
            string? addNotes = Console.ReadLine();

            string? resAN = this._strval.CheckNoteslValidity(addNotes);

            if (resAN != null)
            {
                Console.WriteLine(resAN);
                return;
            }

            ContactInfo contact =
                new ContactInfo(name, phoneNumber, emailAddress, addNotes);

            this._con.AddContact(contact);
        }

        /// <summary>
        /// Allows the user to modify details of an existing contact.
        /// </summary>
        public void GetEdit()
        {
            Console.Write("Enter the name of the contact you want to edit:");

            string? name = Console.ReadLine();

            ContactInfo contact = this._con.GetContactByName(name);
            Guid contact1 = this._con.GetGuidByName(name);

            if (contact != null)
            {
                Console.Write("Enter the detail you want to edit.\n1.Name\n2.Phone Number\n3.Email address\n4.Notes\nEnter the option number:");

                string detailtxt = Console.ReadLine();
                if(_strval.IsNumchice(detailtxt) == false)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                int detail = Convert.ToInt32(detailtxt);
                if (detail == 1)
                {
                    Console.Write("Enter new name:");
                    string? editName = Console.ReadLine();
                    string? resName = this._strval.CheckStrValidity(editName);

                    if (resName != null)
                    {
                        Console.WriteLine(resName);
                        return;
                    }

                    contact.Name = editName;
                    this._con.EditContact(contact, contact1);
                }
                else if (detail == 2)
                {
                    Console.Write("Enter new phone number:");

                    string? editphnNumstr = Console.ReadLine();
                    string? resNum = this._strval.CheckNumValidity(editphnNumstr);

                    if (resNum != null)
                    {
                        Console.WriteLine(resNum);
                        return;
                    }

                    long editPhoneNumber = Convert.ToInt64(editphnNumstr);
                    contact.PhoneNumber = editPhoneNumber;

                    this._con.EditContact(contact, contact1);
                }
                else if (detail == 3)
                {
                    Console.Write("Enter new email address:");

                    string? editEmailAddress = Console.ReadLine();
                    string? resEA = this._strval.CheckEmailValidity(editEmailAddress);

                    if (resEA != null)
                    {
                        Console.WriteLine(resEA);
                        return;
                    }

                    contact.EmailId = editEmailAddress;
                    this._con.EditContact(contact, contact1);
                }
                else if (detail == 4)
                {
                    Console.Write("Enter new notes:");

                    string? editNotes = Console.ReadLine();
                    string? resAN = this._strval.CheckNoteslValidity(editNotes);

                    if (resAN != null)
                    {
                        Console.WriteLine(resAN);
                        return;
                    }

                    contact.Notes = editNotes;
                    this._con.EditContact(contact, contact1);
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
        internal void GetView()
        {
            this._con.ViewContact();
        }

        /// <summary>
        /// This checks if the contact list is empty and displays a message if no contacts are found.
        /// </summary>
        internal void IscontactsEmpty()
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        /// <summary>
        /// Searches for a contact by name and displays the result.
        /// </summary>
        internal void GetSearch()
        {
            Console.WriteLine("Enter the name of the contact you want to search");

            string? name = Console.ReadLine();

            string? resName = this._strval.CheckStrValidity(name);

            if (resName != null)
            {
                Console.WriteLine(resName);
                return;
            }

            this._con.SearchContact(name);
        }

        /// <summary>
        /// Removes a contact from the system by name.
        /// </summary>
        internal void GetRemove()
        {
            Console.WriteLine("Enter the name of the contact you want to remove");

            string? name = Console.ReadLine();

            string? resName = this._strval.CheckStrValidity(name);

            if (resName != null)
            {
                Console.WriteLine(resName);
                return;
            }

            this._con.RemoveContact(name);
        }
    }
}