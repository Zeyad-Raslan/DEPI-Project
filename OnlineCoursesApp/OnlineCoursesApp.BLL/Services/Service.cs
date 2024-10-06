using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;

public class Service<T> : IService<T> where T : class
{
    private readonly OnlineCoursesContext _context;
    private readonly DbSet<T> _dbSet;

    public Service(OnlineCoursesContext context)
    {
        _context = context;
        _dbSet = context.Set<T>(); // إنشاء DbSet للكائن
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable(); // إرجاع استعلام للكائنات
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id); // إيجاد الكائن باستخدام الـ id
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity); // إضافة الكائن
        _context.SaveChanges(); // حفظ التغييرات
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity); // تحديث الكائن
        _context.SaveChanges(); // حفظ التغييرات
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbSet.Remove(entity); // إزالة الكائن
            _context.SaveChanges(); // حفظ التغييرات
        }
    }
}
