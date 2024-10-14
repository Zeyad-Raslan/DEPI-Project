using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using System.Linq;

public class Service<T> : IService<T> where T : class
{
    private readonly OnlineCoursesContext _context;
    private readonly DbSet<T> _dbSet;

    public Service(OnlineCoursesContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    // Queryable method for fetching entities
    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    // Fetch entity by ID
    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    // Add a new entity
    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();  // Immediate save
    }

    // Update an existing entity
    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();  // Immediate save
    }

    // Delete by ID
    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();  // Immediate save
        }
    }

    // Delete by passing entity
    public void Delete(T entity)
    {
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();  // Immediate save
        }
    }
}
