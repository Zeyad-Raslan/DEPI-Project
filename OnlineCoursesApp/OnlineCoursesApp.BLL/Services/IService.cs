using System.Linq;

namespace OnlineCoursesApp.BLL.Services
{
    public interface IService<T> where T : class
    {
        // Retrieve all entities in a queryable format (for filtering, ordering, etc.)
        IQueryable<T> Query();

        // Retrieve a single entity by its ID
        T GetById(int id);

        // Add a new entity
        void Add(T entity);

        // Update an existing entity
        void Update(T entity);

        // Delete an entity by its ID
        void Delete(int id);

        // Optional: Save changes to persist data to the database
        void SaveChanges();
    }
}
