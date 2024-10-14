using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
<<<<<<< HEAD
using System.Linq;

=======

// can create service class from different models
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
public class Service<T> : IService<T> where T : class
{
    private readonly OnlineCoursesContext _context;
    private readonly DbSet<T> _dbSet;

    public Service(OnlineCoursesContext context)
    {
        _context = context;
<<<<<<< HEAD
        _dbSet = context.Set<T>();
    }

    // Queryable method for fetching entities
    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    // Fetch entity by ID
=======
        _dbSet = context.Set<T>(); 
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable(); 
    }

>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

<<<<<<< HEAD
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
=======
    public void Add(T entity)
    {
        _dbSet.Add(entity); 
        _context.SaveChanges(); 
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges(); 
    }

>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
<<<<<<< HEAD
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
=======
            _dbSet.Remove(entity); 
            _context.SaveChanges(); 
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
        }
    }
}
