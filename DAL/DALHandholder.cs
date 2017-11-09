using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using VanillaPuddingAPI.DAL;

public class DALHandholder{
#region Client hand holders
	public Client GetClient(int clientId){
		using(var db = new Context()){
			List<Client> clients = db.Clients.Where(x => x.ClientId == clientId).ToList();
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
#endregion
#region Contact hand holders
	public Contact GetContact(int contactId){
		using(var db = new Context()){
			List<Contact> contacts = db.Contacts.Where(x => x.ContactId == contactId).ToList();
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
			if(db.Contacts.Where(c => c.ContactId == contact.ContactId).Count() == 0)
				db.Contacts.Add(contact);
			else
				db.Contacts.Update(contact);
			try{
				db.SaveChanges();
			}
			catch(Exception e){
				shitBucket.AddError(e.Message);
			}
		return contact;
		}
	}
	public void DeleteContact(ShitBucket shitBucket, int contactId){
		using(var db = new Context()){
			db.Contacts.Remove(db.Contacts.Where(c => c.ContactId == contactId).FirstOrDefault());
			try{
				db.SaveChanges();
			}
			catch(Exception e){
				shitBucket.AddError(e.Message);
			}
		}
	}
#endregion
#region Order hand holders
	public Order GetOrder(int orderId){
		using(var db = new Context()){
			List<Order> orders = db.Orders.Where(x => x.OrderId == orderId).ToList();
			if(orders.Count > 0){
				return orders.FirstOrDefault();
			}
			else{
				return null;
			}
		}
	}
	public List<Order> GetOrders(string orderBy = ""){
		using(var db = new Context()){
			if(string.IsNullOrWhiteSpace(orderBy))
				return db.Orders.ToList();
			else{
				return db.Orders.OrderBy(c => c.GetType().GetProperty(orderBy)).ToList();
			}
		}
	}
	public Order AddEditOrder(ShitBucket shitBucket, Order order){
		using(var db = new Context()){
			if(db.Orders.Where(c => c.OrderId == order.OrderId).Count() == 0)
				db.Orders.Add(order);
			else
				db.Orders.Update(order);
			try{
				db.SaveChanges();
			}
			catch(Exception e){
				shitBucket.AddError(e.Message);
			}
		return order;
		}
	}
	public void DeleteOrder(ShitBucket shitBucket, int orderId){
		using(var db = new Context()){
			db.Orders.Remove(db.Orders.Where(c => c.OrderId == orderId).FirstOrDefault());
			try{
				db.SaveChanges();
			}
			catch(Exception e){
				shitBucket.AddError(e.Message);
			}
		}
	}
#endregion

}