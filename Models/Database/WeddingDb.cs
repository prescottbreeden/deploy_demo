using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Models
{
  public class WeddingDb : DbContext
  {
    public WeddingDb(DbContextOptions<WeddingDb> options) : base(options) { }
    public DbSet<User> users { get; set; }
    public DbSet<Wedding> weddings { get; set; }
    public DbSet<Address> addresses { get; set; }
    public DbSet<Guest> guests { get; set; }


    // ============================== //
    //          USER API
    // ============================== //

    public List<User> GetAllUsers()
    {
      return users.ToList();
    }

    public User GetOneUser(int id)
    {
      return users.FirstOrDefault(u => u.user_id == id);
    }

    public User GetOneUser(string email)
    {
      return users.FirstOrDefault(u => u.email == email);
    }

    public string LoginValidation(LoginUser user)
    {
      var isUser = users.FirstOrDefault(u => u.email == user.LogEmail);
      if(isUser is null)
      {
        return "Email not found";
      }
      else 
      {
        var hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(
          user, isUser.password, user.LogPassword);

          if(result == 0)
          {
            return "Incorrect password";
          }
      }
      return "Success";
    }

    public void CreateNewUser(User newUser)
    {
      PasswordHasher<User> Hasher = new PasswordHasher<User>();
      newUser.password = Hasher.HashPassword(newUser, newUser.password); 
      users.Add(newUser);
      SaveChanges();
    }

    public void UpdateUser(User user)
    {
      User current = GetOneUser(user.user_id);
      current.name = user.name;
      current.email = user.email;
      current.updated_at = DateTime.Now;
      SaveChanges();
    }

    public void DeleteUser(int id)
    {
      User removeThis = users.SingleOrDefault(u => u.user_id == id);
      users.Remove(removeThis);
      SaveChanges();
    }


    // ============================== //
    //          WEDDING API
    // ============================== //

    public List<Wedding> GetAllWeddings()
    {
      return weddings.ToList();
    }

    public Wedding GetOneWedding(int id)
    {
      return weddings.FirstOrDefault(w => w.wedding_id == id);
    }

    public void DeleteWedding(int id)
    {
      Wedding removeThis = weddings.SingleOrDefault(w => w.wedding_id == id);
      weddings.Remove(removeThis);
      SaveChanges();
    }

    public void CreateNewWedding(NewWedding newWedding)
    {
      Address address = new Address();
      address.street = newWedding.Street;
      address.city = newWedding.City;
      address.state = newWedding.State;
      address.zip_code = newWedding.Zip;
      CreateNewAddress(address);
      SaveChanges();

      Wedding wedding = new Wedding();
      wedding.address_id = address.address_id;
      wedding.user_id = newWedding.UserId;
      wedding.wedder_one = newWedding.WedderOne;
      wedding.wedder_two = newWedding.WedderTwo;
      wedding.wedding_date = newWedding.Date;

      weddings.Add(wedding);
      SaveChanges();
    }

    public void UpdateWedding(Wedding wedding)
    {
      Wedding current = GetOneWedding(wedding.wedding_id);
      current.wedder_one = wedding.wedder_one;
      current.wedder_two = wedding.wedder_two;
      current.wedding_date = wedding.wedding_date;
      current.updated_at = DateTime.Now;
      SaveChanges();
    }


    // ============================== //
    //          ADDRESS API
    // ============================== //

    public void CreateNewAddress(Address address)
    {
      System.Console.WriteLine("...... Inside Create Address ........");
      System.Console.WriteLine(address.address_id);
      addresses.Add(address);
      SaveChanges();
    }
  }

}