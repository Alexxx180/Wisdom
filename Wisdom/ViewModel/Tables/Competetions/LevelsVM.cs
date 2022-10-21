using ControlMaterials.Tables.Tasks;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Numeration;

namespace Wisdom.ViewModel.Tables.Competetions
{
    public class LevelsVM : TNode<LevelVM>
    {
        public LevelsVM()
        {
            Items = new AutoList<LevelVM>(new LevelVM(this, new Level()));
            Items.Options.Add(new StateBlock<LevelVM>(Numerable.Collection(Items)));
        }
    }
}
