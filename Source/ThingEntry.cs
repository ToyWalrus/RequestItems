﻿using RimWorld;
using UnityEngine;
using Verse;

namespace ItemRequests
{
    public class ThingEntry : IExposable
    {
        public ThingDef def;
        public ThingDef stuffDef = null;
        public Gender gender = Gender.None;
        public Thing thing = null;
        public Tradeable tradeable = null;
        public PawnKindDef pawnDef = null;
        public ThingType type;
        public int stackSize;
        public double cost = 0;
        public Color color = Color.white;
        public bool stacks = true;
        public bool gear = false;
        public bool animal = false;
        protected string label = null;
        public bool hideFromPortrait = false;

        public ThingEntry Clone()
        {
            ThingEntry cloned = new ThingEntry();
            cloned.def = def;
            cloned.stuffDef = stuffDef;
            cloned.gender = gender;
            cloned.tradeable = tradeable == null ? 
                null : 
                new Tradeable(tradeable.FirstThingColony, tradeable.FirstThingTrader);
            cloned.thing = thing;
            cloned.pawnDef = pawnDef;
            cloned.type = type;
            cloned.stackSize = stackSize;
            cloned.cost = cost;
            cloned.color = color;
            cloned.stacks = stacks;
            cloned.gear = gear;
            cloned.animal = animal;
            cloned.label = label;
            cloned.hideFromPortrait = hideFromPortrait;
            return cloned;
        }

        public bool Minifiable
        {
            get
            {
                return def.Minifiable && def.building != null;
            }
        }

        public string Label
        {
            get
            {
                if (label == null)
                {
                    if (thing != null && animal == true)
                    {
                        return LabelForAnimal;
                    }
                    else
                    {
                        return GenLabel.ThingLabel(def, stuffDef, stackSize).CapitalizeFirst();
                    }
                }
                else
                {
                    return label;
                }
            }
        }

        public string LabelNoCount
        {
            get
            {
                if (label == null)
                {
                    if (thing != null && animal == true)
                    {
                        return LabelForAnimal;
                    }
                    else
                    {
                        return GenLabel.ThingLabel(def, stuffDef, 1).CapitalizeFirst();
                    }
                }
                else
                {
                    return label;
                }
            }
        }

        public string LabelForAnimal
        {
            get
            {
                Pawn pawn = thing as Pawn;
                if (pawn.def.race.hasGenders)
                {
                    return pawn.kindDef.label.CapitalizeFirst();
                }
                else
                {
                    return pawn.LabelCap;
                }
            }
        }

        public ThingKey ThingKey
        {
            get
            {
                return new ThingKey(def, stuffDef, gender);
            }
        }

        public void ExposeData()
        {
            Scribe_Defs.Look(ref def, "def");
            Scribe_Defs.Look(ref stuffDef, "stuffDef");
            Scribe_Values.Look(ref gender, "gender", Gender.None);
            Scribe_Deep.Look(ref thing, "thing");
            Scribe_Deep.Look(ref tradeable, true, "tradeable", new object[] { null, thing });
            Scribe_Defs.Look(ref pawnDef, "pawnDef");
            Scribe_Values.Look(ref type, "type", ThingType.Other);
            Scribe_Values.Look(ref stackSize, "stackSize");
            Scribe_Values.Look(ref cost, "cost");
            Scribe_Values.Look(ref color, "color");
            Scribe_Values.Look(ref stacks, "stacks");
            Scribe_Values.Look(ref gear, "gear");
            Scribe_Values.Look(ref animal, "animal");
            Scribe_Values.Look(ref label, "label");
            Scribe_Values.Look(ref hideFromPortrait, "hideFromPortrait");
        }

        public override string ToString()
        {
            return string.Format("[ThingEntry: def = {0}, stuffDef = {1}, gender = {2}]",
                (def != null ? def.defName : "null"),
                (stuffDef != null ? stuffDef.defName : "null"),
                gender);
        }
    }



}

