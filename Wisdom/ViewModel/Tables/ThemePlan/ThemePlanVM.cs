﻿using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Total;
using Wisdom.ViewModel.Collections;
using Wisdom.ViewModel.Collections.Features;
using Wisdom.ViewModel.Collections.Features.Count;
using Wisdom.ViewModel.Collections.Features.Count.Highlighting;
using Wisdom.ViewModel.Collections.Features.Numeration;
using static Wisdom.ViewModel.DisciplineProgramViewModel;

namespace Wisdom.ViewModel.Tables.ThemePlan
{
    public class ThemePlanVM : TNode<TopicVM>, ICount, IHighlighting, ICloneable<ThemePlanVM>
    {
        public Countable Count { get; }
        public Highlightable Coloring { get; }

        public ThemePlanVM(Plan plan)
        {
            _plan = plan;

            Bridge<ISummator> sumLogic = new Bridge<ISummator>();
            Count = new Countable(this, sumLogic);
            Coloring = new Highlightable(this, sumLogic);

            Items = new AutoList<TopicVM>(new TopicVM(this, new Topic()));
            Items.Options.Add(new StateBlock<TopicVM>(Numerable.Collection(Items)));
            Items.Options.Add(new StateBlock<TopicVM>(Count.Collection(Items)));
            Items.Options.Add(new StateBlock<TopicVM>(Coloring.Collection(Items)));
        }

        public void TrackChanges(ref OnSelect select)
        {
            Items.Options[0].TrackChanges(ref select);
        }

        private readonly Plan _plan;

        public ushort Hours
        {
            get => _plan.Sum;
            set
            {
                _plan.Sum = value;
                OnPropertyChanged();
            }
        }

        public ThemePlanVM Copy()
        {
            return new ThemePlanVM(_plan.Copy());
        }
    }
}
