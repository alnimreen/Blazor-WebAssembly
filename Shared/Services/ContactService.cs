using ContactProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactProject.Shared.Services
{
    public class ContactService
    {
        private List<Contact> contacts = new List<Contact>();

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public void AddContact(Contact contact)
        {
            contact.Id = contacts.Count + 1; 
            contacts.Add(contact);
        }

        public async Task UpdateContact(Contact updatedContact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.Id == updatedContact.Id);
            if (existingContact != null)
            {
                // Create a copy of the updated contact
                var updatedCopy = new Contact
                {
                    Id = existingContact.Id,
                    FirstName = updatedContact.FirstName,
                    LastName = updatedContact.LastName,
                    Email = updatedContact.Email,
                    PhoneNumber = updatedContact.PhoneNumber
                };

                // Find the index of the existing contact
                var index = contacts.IndexOf(existingContact);
                // Replace the existing contact with the updated copy
                contacts[index] = updatedCopy;
            }
        }


        public void DeleteContact(int contactId)
        {
            var contactToRemove = contacts.FirstOrDefault(c => c.Id == contactId);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
            }
        }
    }
    }
