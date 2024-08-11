using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T: class //Dışarıdan bir T değeri alıcak. Gelen bu T değeri de bir class olmalı.
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter); //T ile bir giriş değeri tanımlanıyor. bool olarak da çıkış değeri tanımlanıyor. Yani true  veya false dönecek. Filter gönderilen parametreyi tutar.

    }
}
