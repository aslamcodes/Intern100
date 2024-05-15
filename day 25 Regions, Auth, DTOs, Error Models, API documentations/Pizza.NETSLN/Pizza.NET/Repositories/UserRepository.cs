using Microsoft.EntityFrameworkCore;
using Pizza.NET.Contexts;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;

namespace Pizza.NET.Repositories
{
    public class UserRepository(PizzaChainContext context) : IRepository<int, Models.User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="FailedToAddUser"></exception>
        public async Task<User> Add(User entity)
        {


            try
            {
                context.Users.Add(entity);

                int result = await context.SaveChangesAsync();

                if (result == 0)
                {
                    throw new FailedToAddUser();
                }

                return entity;

            }
            catch (FailedToAddUser)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> Delete(int key)
        {
            try
            {
                var user = await GetByKey(key);

                context.Users.Remove(user);

                var result = await context.SaveChangesAsync();

                if (result == 0)
                {
                    throw new FailedToDeleteUserException();
                }

                return user;
            }
            catch (FailedToDeleteUserException)
            {
                throw;
            }
            catch (NoUserFoundException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var users = await context.Users.ToListAsync();

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetByKey(int key)
        {
            try
            {
                var pizza = await context.Users.FindAsync(key);

                return pizza ?? throw new NoPizzaFoundException(key);
            }
            catch (NoUserFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> Update(User entity)
        {
            try
            {
                context.Users.Remove(entity);

                var result = await context.SaveChangesAsync();

                if (result == 0)
                {
                    throw new FailedToUpdateUser();
                }

                return entity;
            }
            catch (FailedToUpdatePizzaException)
            {

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);

                return user ?? throw new NoUserFoundException();
            }
            catch (NoUserFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}