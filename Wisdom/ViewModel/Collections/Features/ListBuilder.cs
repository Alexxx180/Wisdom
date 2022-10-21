using ControlMaterials.Total;
using ControlMaterials.Total.Count;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Numeration;

namespace Wisdom.ViewModel.Collections.Features
{
    public class CountDecorator<T> where T : IChangeable, ICloneable<T>
    {
        private AutoList<T> _product;

        // A fresh builder instance should contain a blank product object, which
        // is used in further assembly.
        public CountDecorator(T additor)
        {
            Reset(additor);
        }

        public void Reset(T additor)
        {
            _product = new AutoList<T>(additor);
        }

        // All production steps work with the same product instance.
        public void SetCount(Bridge<ISummator> count)
        {
            //StateBlock<T> count = new StateBlock<T>();
            //count.States.Add(new Count.ManualCount<T>(count, ""));
            //_product.Options.Add(count);
        }

        public void SetNumeration()
        {
            //StateBlock<T> count = new StateBlock<T>();
            //count.States.Add(new ManualNumeration<T>());
            //_product.Options.Add(count);
        }
    }
}
