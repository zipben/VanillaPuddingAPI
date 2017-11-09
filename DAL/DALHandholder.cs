using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using VanillaPuddingAPI.DAL;

public class DALHandholder{
    public Client GetClient(int clientId){
        using(var db = new Context()){
            List<Client> clients = db.Clients.Where(c => c.ClientId == clientId).ToList();

            if(clients.Count > 0){
                return clients.FirstOrDefault();
            }
            else{
                return null;
            }
        }
    }
    public List<Client> GetClients(string orderBy = ""){
        using(var db = new Context()){

          if(string.IsNullOrWhiteSpace(orderBy))
              return db.Clients.ToList();
          else{
              return db.Clients.OrderBy(c => c.GetType().GetProperty(orderBy)).ToList();    
          }
        }
    }

    public Client AddEditClient(ShitBucket shitBucket, Client client){
        using(var db = new Context()){
            
            //Client targetClient = db.Clients.Contains(c => c.ClientId == client.ClientId);
            if(db.Clients.Where(c => c.ClientId == client.ClientId).Count() == 0)
                db.Clients.Add(client);
            else
                db.Clients.Update(client);
            try{
                db.SaveChanges();
            }
            catch(Exception e){
                shitBucket.AddError(e.Message);
            }

            return client;
        }
    }

    public void DeleteClient(ShitBucket shitBucket, int clientId){
        using(var db = new Context()){
            db.Clients.Remove(db.Clients.Where(c => c.ClientId == clientId).FirstOrDefault());
            try{
                db.SaveChanges();
            }
            catch(Exception e){
                shitBucket.AddError(e.Message);
            }
        }
    }

    public Contact GetContact(int contactId){
         using(var db = new Context()){
            List<Contact> contacts = db.Contacts.Where(c => c.ContactId == contactId).ToList();

            if(contacts.Count > 0){
                return contacts.FirstOrDefault();
            }
            else{
                return null;
            }
        }
    }

    public List<Contact> GetContacts(string orderBy = ""){
        using(var db = new Context()){
            if(string.IsNullOrWhiteSpace(orderBy))
                return db.Contacts.ToList();
            else{
                return db.Contacts.OrderBy(c => c.GetType().GetProperty(orderBy)).ToList();    
            }
        } 
    }
      
      
    public Contact AddEditContact(ShitBucket shitBucket, Contact contact){
        using(var db = new Context()){
            
            //Client targetClient = db.Clients.Contains(c => c.ClientId == client.ClientId);
            if(db.Contacts.Where(c => c.ContactId == contact.ContactId).Count() == 0)
                db.Contacts.Add(contact);
            else
                db.Contacts.Update(contact);
          
          return contact;
        }
    }
}