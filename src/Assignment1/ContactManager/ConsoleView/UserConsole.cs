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

            string outChoice = _strval.IsChoiceValid(userChoice);

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
            Console.WriteLine("Enter your name");
            string? name = Console.ReadLine();

            string resName = _strval.CheckStrValidity(name);

            if (resName != null)
            {
                Console.WriteLine(resName);
                return;
            }

            Console.WriteLine("Enter your Phone number");
            string? phoneNumStr = Console.ReadLine();

            string resNum = _strval.CheckNumValidity(phoneNumStr);

            if (resNum != null)
            {
                Console.WriteLine(resNum);
                return;
            }

            long phoneNumber = Convert.ToInt64(phoneNumStr);

            Console.WriteLine("Enter your email address");
            string? emailAddress = Console.ReadLine();

            string resEA = _strval.CheckEmailValidity(emailAddress);

            if (resEA != null)
            {
                Console.WriteLine(resEA);
                return;
            }

            Console.WriteLine("Enter additional notes");
            string? addNotes = Console.ReadLine();

            string resAN = _strval.CheckNoteslValidity(addNotes);

            if (resAN != null)
            {
                Console.WriteLine(resAN);
                return;
            }

            ContactInfo contact =
                new ContactInfo(name, phoneNumber, emailAddress, addNotes);

            _con.AddContact(contact);
        }

        /// <summary>
        /// Allows the user to modify details of an existing contact.
        /// </summary>
        public void GetEdit()
        {
            Console.WriteLine("Enter the name of the contact you want to edit");

            string? name = Console.ReadLine();

            ContactInfo contact = _con.GetContactByName(name);
            Guid contact1 = _con.GetGuidByName(name);

            if (contact != null)
            {
                Console.WriteLine(
                    "Enter the detail you want to edit.\n1.Name\n2.Phone Number\n3.Email address\n4.Notes\nEnter the option number:");

                int detail = Convert.ToInt32(Console.ReadLine());

                if (detail == 1)
                {
                    Console.WriteLine("Enter new name");

                    string? editName = Console.ReadLine();
                    string resName = _strval.CheckStrValidity(editName);

                    if (resName != null)
                    {
                        Console.WriteLine(resName);
                        return;
                    }

                    contact.Name = editName;
                    _con.EditContact(contact, contact1);
                }
                else if (detail == 2)
                {
                    Console.WriteLine("Enter new phone number");

                    string? editphnNumstr = Console.ReadLine();
                    string resNum = _strval.CheckNumValidity(editphnNumstr);

                    if (resNum != null)
                    {
                        Console.WriteLine(resNum);
                        return;
                    }

                    long editPhoneNumber = Convert.ToInt64(editphnNumstr);
                    contact.PhoneNumber = editPhoneNumber;

                    _con.EditContact(contact, contact1);
                }
                else if (detail == 3)
                {
                    Console.WriteLine("Enter new email address");

                    string? editEmailAddress = Console.ReadLine();
                    string resEA = _strval.CheckEmailValidity(editEmailAddress);

                    if (resEA != null)
                    {
                        Console.WriteLine(resEA);
                        return;
                    }

                    contact.EmailId = editEmailAddress;
                    _con.EditContact(contact, contact1);
                }
                else if (detail == 4)
                {
                    Console.WriteLine("Enter new notes");

                    string? editNotes = Console.ReadLine();
                    string resAN = _strval.CheckNoteslValidity(editNotes);

                    if (resAN != null)
                    {
                        Console.WriteLine(resAN);
                        return;
                    }

                    contact.Notes = editNotes;
                    _con.EditContact(contact, contact1);
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
            _con.ViewContact();
        }

        /// <summary>
        /// Searches for a contact by name and displays the result.
        /// </summary>
        internal void GetSearch()
        {
            Console.WriteLine("Enter the name of the contact you want to search");

            string? name = Console.ReadLine();

            string resName = _strval.CheckStrValidity(name);

            if (resName != null)
            {
                Console.WriteLine(resName);
                return;
            }

            _con.SearchContact(name);
        }
        /// <summary>
        /// Removes a contact from the system by name.
        /// </summary>
        internal void GetRemove()
        {
            Console.WriteLine("Enter the name of the contact you want to remove");

            string? name = Console.ReadLine();

            string resName = _strval.CheckStrValidity(name);

            if (resName != null)
            {
                Console.WriteLine(resName);
                return;
            }

            _con.RemoveContact(name);
        }
    }
}