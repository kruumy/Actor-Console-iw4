namespace ActorConsole.Classes
{
    internal static class PlayerModels
    {

        // list from https://pastebin.com/qyUGnc4b

        public static string[] allMaps = { "AFGHAN", "DERAIL", "ESTATE", "FAVELA", "HIGHRISE", "INVASION", "CHECKPOINT", "KARACHI", "QUARRY", "UNDOWN", "RUST", "BONEYARD"
                ,"SCRAPYARD","NIGHTSHIFT","SKIDROW","SUBBASE","TERMINAL","UNDERPASS","BRECOURT","WASTELAND","COMPLEX","BAILOUT","CRASH","OVERGROWN","COMPACT","SALVAGE","STORM"
                ,"ABANDON","CARNIVAL","FUEL2","FUEL","STRIKE","TRAILERPARK","VACANT" };
        public static string[] AFGHAN(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] AFGHANHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_allies_tf141_desert_sniper
                                                head_riot_tf141_desert
                                                head_allies_sniper_ghillie_desert
                                                head_opforce_arab_a
                                                head_opforce_arab_b
                                                head_opforce_arab_c
                                                head_opforce_arab_d_hat
                                                head_opforce_arab_e
                                                head_op_arab_sniper
                                                head_riot_op_arab
                                                head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return AFGHANHead;
                    }
                case "body":
                    {
                        string[] AFGHANBody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_tf141_desert_sniper
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_desert
                                                mp_body_opforce_arab_assault_a
                                                mp_body_opforce_arab_lmg_a
                                                mp_body_opforce_arab_shotgun_a
                                                mp_body_opforce_arab_smg_a
                                                mp_body_op_arab_sniper
                                                mp_body_riot_op_arab
                                                mp_body_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return AFGHANBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] DERAIL(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] DERAILHead = @"head_tf141_arctic_a
                                                head_tf141_arctic_b
                                                head_tf141_arctic_c
                                                head_tf141_arctic_d
                                                head_allies_tf141_arctic_sniper
                                                head_riot_tf141_arctic
                                                head_allies_sniper_ghillie_arctic
                                                head_opforce_arctic_a
                                                head_opforce_arctic_b
                                                head_opforce_arctic_c
                                                head_opforce_arctic_d
                                                head_op_arctic_sniper
                                                head_riot_op_arctic
                                                head_op_sniper_ghillie_arctic".Replace(" ", string.Empty).Split('\n');
                        return DERAILHead;
                    }
                case "body":
                    {
                        string[] DERAILBody = @"mp_body_tf141_assault_a
                                                mp_body_tf141_assault_b
                                                mp_body_tf141_lmg
                                                mp_body_tf141_smg
                                                mp_body_tf141_shotgun
                                                mp_body_tf141_arctic_sniper
                                                mp_body_riot_tf141_arctic
                                                mp_body_ally_sniper_ghillie_arctic
                                                mp_body_opforce_arctic_assault_a
                                                mp_body_opforce_arctic_assault_b
                                                mp_body_opforce_arctic_assault_c
                                                mp_body_opforce_arctic_lmg
                                                mp_body_opforce_arctic_lmg_b
                                                mp_body_opforce_arctic_lmg_c
                                                mp_body_opforce_arctic_shotgun
                                                mp_body_opforce_arctic_shotgun_b
                                                mp_body_opforce_arctic_shotgun_c
                                                mp_body_opforce_arctic_smg
                                                mp_body_opforce_arctic_smg_b
                                                mp_body_opforce_arctic_smg_c
                                                mp_body_op_arctic_sniper
                                                mp_body_riot_op_arctic
                                                mp_body_op_sniper_ghillie_arctic".Replace(" ", string.Empty).Split('\n');
                        return DERAILBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] ESTATE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] ESTATEHead = @"head_tf141_forest_a
                                                head_tf141_forest_b
                                                head_tf141_forest_c
                                                head_tf141_forest_d
                                                head_allies_tf141_forest_sniper
                                                head_riot_tf141_forest
                                                head_allies_sniper_ghillie_forest
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return ESTATEHead;
                    }
                case "body":
                    {
                        string[] ESTATEBody = @"mp_body_forest_tf141_assault_a
                                                mp_body_forest_tf141_assault_b
                                                mp_body_forest_tf141_lmg
                                                mp_body_forest_tf141_smg
                                                mp_body_forest_tf141_shotgun
                                                mp_body_tf141_forest_sniper
                                                mp_body_riot_tf141_forest
                                                mp_body_ally_sniper_ghillie_forest
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne
                                                mp_body_op_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return ESTATEBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] FAVELA(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] FAVELAHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_allies_tf141_desert_sniper
                                                head_riot_tf141_desert
                                                head_allies_sniper_ghillie_urban
                                                head_militia_ba_blk
                                                head_militia_bb_blk_hat
                                                head_militia_bc_blk
                                                head_militia_bd_blk
                                                head_militia_a_wht
                                                head_riot_op_militia
                                                head_op_militia_sniper
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return FAVELAHead;
                    }
                case "body":
                    {
                        string[] FAVELABody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_tf141_desert_sniper
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_militia_assault_aa_blk
                                                mp_body_militia_assault_aa_wht
                                                mp_body_militia_assault_ab_blk
                                                mp_body_militia_assault_ac_blk
                                                mp_body_militia_lmg_aa_blk
                                                mp_body_militia_lmg_ab_blk
                                                mp_body_militia_lmg_ac_blk
                                                mp_body_militia_smg_aa_blk
                                                mp_body_militia_smg_aa_wht
                                                mp_body_militia_smg_ab_blk
                                                mp_body_militia_smg_ac_blk
                                                mp_body_op_miltia_sniper
                                                mp_body_riot_op_militia
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return FAVELABody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] HIGHRISE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] HIGHRISEHead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_f
                                                head_us_army_e
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return HIGHRISEHead;
                    }
                case "body":
                    {
                        string[] HIGHRISEBody = @"mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_assault_a
                                                mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_us_army_smg
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_us_army_lmg
                                                mp_body_us_army_riot
                                                mp_body_army_sniper
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return HIGHRISEBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] INVASION(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] INVASIONHead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_f
                                                head_us_army_e
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_opforce_arab_a
                                                head_opforce_arab_b
                                                head_opforce_arab_c
                                                head_opforce_arab_d_hat
                                                head_opforce_arab_e
                                                head_op_arab_sniper
                                                head_riot_op_arab
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return INVASIONHead;
                    }
                case "body":
                    {
                        string[] INVASIONBody = @"mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_assault_a
                                                mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_us_army_smg
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_us_army_lmg
                                                mp_body_us_army_riot
                                                mp_body_army_sniper
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_opforce_arab_assault_a
                                                mp_body_opforce_arab_lmg_a
                                                mp_body_opforce_arab_shotgun_a
                                                mp_body_opforce_arab_smg_a
                                                mp_body_op_arab_sniper
                                                mp_body_riot_op_arab
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return INVASIONBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] CHECKPOINT(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] CHECKPOINTHead = @"head_seal_udt_a
                                                    head_seal_udt_c
                                                    head_seal_udt_d
                                                    head_seal_udt_e
                                                    head_allies_seal_udt_sniper
                                                    head_riot_udt
                                                    head_allies_sniper_ghillie_urban
                                                    head_opforce_arab_a
                                                    head_opforce_arab_b
                                                    head_opforce_arab_c
                                                    head_opforce_arab_d_hat
                                                    head_opforce_arab_e
                                                    head_op_arab_sniper
                                                    head_riot_op_arab
                                                    head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CHECKPOINTHead;
                    }
                case "body":
                    {
                        string[] CHECKPOINTBody = @"mp_body_seal_udt_assault_a
                                                    mp_body_seal_udt_assault_b
                                                    mp_body_seal_udt_sniper
                                                    mp_body_seal_udt_lmg
                                                    mp_body_seal_udt_smg
                                                    mp_body_riot_udt
                                                    mp_body_ally_sniper_ghillie_urban
                                                    mp_body_opforce_arab_assault_a
                                                    mp_body_opforce_arab_lmg_a
                                                    mp_body_opforce_arab_shotgun_a
                                                    mp_body_opforce_arab_smg_a
                                                    mp_body_op_arab_sniper
                                                    mp_body_riot_op_arab
                                                    mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CHECKPOINTBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] KARACHI(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] KARACHIHead = @"head_seal_udt_a
                                                    head_seal_udt_c
                                                    head_seal_udt_d
                                                    head_seal_udt_e
                                                    head_allies_seal_udt_sniper
                                                    head_riot_udt
                                                    head_allies_sniper_ghillie_urban
                                                    head_opforce_arab_a
                                                    head_opforce_arab_b
                                                    head_opforce_arab_c
                                                    head_opforce_arab_d_hat
                                                    head_opforce_arab_e
                                                    head_op_arab_sniper
                                                    head_riot_op_arab
                                                    head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return KARACHIHead;
                    }
                case "body":
                    {
                        string[] KARACHIBody = @"mp_body_seal_udt_assault_a
                                                    mp_body_seal_udt_assault_b
                                                    mp_body_seal_udt_sniper
                                                    mp_body_seal_udt_lmg
                                                    mp_body_seal_udt_smg
                                                    mp_body_riot_udt
                                                    mp_body_ally_sniper_ghillie_urban
                                                    mp_body_opforce_arab_assault_a
                                                    mp_body_opforce_arab_lmg_a
                                                    mp_body_opforce_arab_shotgun_a
                                                    mp_body_opforce_arab_smg_a
                                                    mp_body_op_arab_sniper
                                                    mp_body_riot_op_arab
                                                    mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return KARACHIBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] QUARRY(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] QUARRYHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_allies_tf141_desert_sniper
                                                head_riot_tf141_desert
                                                head_allies_sniper_ghillie_desert
                                                head_militia_ba_blk
                                                head_militia_bb_blk_hat
                                                head_militia_bc_blk
                                                head_militia_bd_blk
                                                head_militia_a_wht
                                                head_riot_op_militia
                                                head_op_militia_sniper
                                                head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return QUARRYHead;
                    }
                case "body":
                    {
                        string[] QUARRYBody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_tf141_desert_sniper
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_desert
                                                mp_body_militia_assault_aa_blk
                                                mp_body_militia_assault_aa_wht
                                                mp_body_militia_assault_ab_blk
                                                mp_body_militia_assault_ac_blk
                                                mp_body_militia_lmg_aa_blk
                                                mp_body_militia_lmg_ab_blk
                                                mp_body_militia_lmg_ac_blk
                                                mp_body_militia_smg_aa_blk
                                                mp_body_militia_smg_aa_wht
                                                mp_body_militia_smg_ab_blk
                                                mp_body_militia_smg_ac_blk
                                                mp_body_op_miltia_sniper
                                                mp_body_riot_op_militia
                                                mp_body_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return QUARRYBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] RUNDOWN(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] RUNDOWNHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_allies_tf141_desert_sniper
                                                head_riot_tf141_desert
                                                head_allies_sniper_ghillie_desert
                                                head_militia_ba_blk
                                                head_militia_bb_blk_hat
                                                head_militia_bc_blk
                                                head_militia_bd_blk
                                                head_militia_a_wht
                                                head_riot_op_militia
                                                head_op_militia_sniper
                                                head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return RUNDOWNHead;
                    }
                case "body":
                    {
                        string[] RUNDOWNBody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_tf141_desert_sniper
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_desert
                                                mp_body_militia_assault_aa_blk
                                                mp_body_militia_assault_aa_wht
                                                mp_body_militia_assault_ab_blk
                                                mp_body_militia_assault_ac_blk
                                                mp_body_militia_lmg_aa_blk
                                                mp_body_militia_lmg_ab_blk
                                                mp_body_militia_lmg_ac_blk
                                                mp_body_militia_smg_aa_blk
                                                mp_body_militia_smg_aa_wht
                                                mp_body_militia_smg_ab_blk
                                                mp_body_militia_smg_ac_blk
                                                mp_body_op_miltia_sniper
                                                mp_body_riot_op_militia
                                                mp_body_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return RUNDOWNBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] RUST(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] RUSTHead = @"head_tf141_desert_a
                                            head_tf141_desert_b
                                            head_tf141_desert_c
                                            head_tf141_desert_d
                                            head_allies_tf141_desert_sniper
                                            head_riot_tf141_desert
                                            head_allies_sniper_ghillie_desert
                                            head_opforce_arab_a
                                            head_opforce_arab_b
                                            head_opforce_arab_c
                                            head_opforce_arab_d_hat
                                            head_opforce_arab_e
                                            head_op_arab_sniper
                                            head_riot_op_arab
                                            head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return RUSTHead;
                    }
                case "body":
                    {
                        string[] RUSTBody = @"mp_body_desert_tf141_assault_a
                                            mp_body_desert_tf141_assault_b
                                            mp_body_desert_tf141_lmg
                                            mp_body_desert_tf141_smg
                                            mp_body_desert_tf141_shotgun
                                            mp_body_tf141_desert_sniper
                                            mp_body_riot_tf141_desert
                                            mp_body_ally_sniper_ghillie_desert
                                            mp_body_opforce_arab_assault_a
                                            mp_body_opforce_arab_lmg_a
                                            mp_body_opforce_arab_shotgun_a
                                            mp_body_opforce_arab_smg_a
                                            mp_body_op_arab_sniper
                                            mp_body_riot_op_arab
                                            mp_body_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return RUSTBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] BONEYARD(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] BONEYARDHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_allies_tf141_desert_sniper
                                                head_riot_tf141_desert
                                                head_allies_sniper_ghillie_desert
                                                head_opforce_arab_a
                                                head_opforce_arab_b
                                                head_opforce_arab_c
                                                head_opforce_arab_d_hat
                                                head_opforce_arab_e
                                                head_op_arab_sniper
                                                head_riot_op_arab
                                                head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return BONEYARDHead;
                    }
                case "body":
                    {
                        string[] BONEYARDBody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_tf141_desert_sniper
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_desert
                                                mp_body_opforce_arab_assault_a
                                                mp_body_opforce_arab_lmg_a
                                                mp_body_opforce_arab_shotgun_a
                                                mp_body_opforce_arab_smg_a
                                                mp_body_op_arab_sniper
                                                mp_body_riot_op_arab
                                                mp_body_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return BONEYARDBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] SCRAPYARD(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] SCRAPYARDHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_allies_tf141_desert_sniper
                                                head_riot_tf141_desert
                                                head_allies_sniper_ghillie_desert
                                                head_opforce_arab_a
                                                head_opforce_arab_b
                                                head_opforce_arab_c
                                                head_opforce_arab_d_hat
                                                head_opforce_arab_e
                                                head_op_arab_sniper
                                                head_riot_op_arab
                                                head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return SCRAPYARDHead;
                    }
                case "body":
                    {
                        string[] SCRAPYARDBody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_tf141_desert_sniper
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_desert
                                                mp_body_opforce_arab_assault_a
                                                mp_body_opforce_arab_lmg_a
                                                mp_body_opforce_arab_shotgun_a
                                                mp_body_opforce_arab_smg_a
                                                mp_body_op_arab_sniper
                                                mp_body_riot_op_arab
                                                mp_body_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return SCRAPYARDBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] NIGHTSHIFT(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] NIGHTSHIFTHead = @"head_us_army_a
                                                    head_us_army_b
                                                    head_us_army_c
                                                    head_us_army_d
                                                    head_us_army_f
                                                    head_us_army_e
                                                    head_allies_us_army_sniper
                                                    head_allies_sniper_ghillie_urban
                                                    head_airborne_a
                                                    head_airborne_b
                                                    head_airborne_c
                                                    head_airborne_d
                                                    head_airborne_e
                                                    head_op_airborne_sniper
                                                    head_riot_op_airborne
                                                    head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return NIGHTSHIFTHead;
                    }
                case "body":
                    {
                        string[] NIGHTSHIFTBody = @"mp_body_us_army_lmg_b
                                                    mp_body_us_army_lmg_c
                                                    mp_body_us_army_assault_a
                                                    mp_body_us_army_assault_b
                                                    mp_body_us_army_assault_c
                                                    mp_body_us_army_shotgun
                                                    mp_body_us_army_shotgun_b
                                                    mp_body_us_army_shotgun_c
                                                    mp_body_us_army_smg
                                                    mp_body_us_army_smg_b
                                                    mp_body_us_army_smg_c
                                                    mp_body_us_army_lmg
                                                    mp_body_us_army_riot
                                                    mp_body_army_sniper
                                                    mp_body_ally_sniper_ghillie_urban
                                                    mp_body_airborne_assault_a
                                                    mp_body_airborne_assault_b
                                                    mp_body_airborne_assault_c
                                                    mp_body_airborne_lmg
                                                    mp_body_airborne_lmg_b
                                                    mp_body_airborne_lmg_c
                                                    mp_body_airborne_shotgun
                                                    mp_body_airborne_shotgun_b
                                                    mp_body_airborne_shotgun_c
                                                    mp_body_airborne_smg
                                                    mp_body_airborne_smg_b
                                                    mp_body_airborne_smg_c
                                                    mp_body_op_airborne_sniper
                                                    mp_body_riot_op_airborne
                                                    mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return NIGHTSHIFTBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] SKIDROW(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] SKIDROWHead = @"head_us_army_a
                                                    head_us_army_b
                                                    head_us_army_c
                                                    head_us_army_d
                                                    head_us_army_f
                                                    head_us_army_e
                                                    head_allies_us_army_sniper
                                                    head_allies_sniper_ghillie_urban
                                                    head_airborne_a
                                                    head_airborne_b
                                                    head_airborne_c
                                                    head_airborne_d
                                                    head_airborne_e
                                                    head_op_airborne_sniper
                                                    head_riot_op_airborne
                                                    head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return SKIDROWHead;
                    }
                case "body":
                    {
                        string[] SKIDROWBody = @"mp_body_us_army_lmg_b
                                                    mp_body_us_army_lmg_c
                                                    mp_body_us_army_assault_a
                                                    mp_body_us_army_assault_b
                                                    mp_body_us_army_assault_c
                                                    mp_body_us_army_shotgun
                                                    mp_body_us_army_shotgun_b
                                                    mp_body_us_army_shotgun_c
                                                    mp_body_us_army_smg
                                                    mp_body_us_army_smg_b
                                                    mp_body_us_army_smg_c
                                                    mp_body_us_army_lmg
                                                    mp_body_us_army_riot
                                                    mp_body_army_sniper
                                                    mp_body_ally_sniper_ghillie_urban
                                                    mp_body_airborne_assault_a
                                                    mp_body_airborne_assault_b
                                                    mp_body_airborne_assault_c
                                                    mp_body_airborne_lmg
                                                    mp_body_airborne_lmg_b
                                                    mp_body_airborne_lmg_c
                                                    mp_body_airborne_shotgun
                                                    mp_body_airborne_shotgun_b
                                                    mp_body_airborne_shotgun_c
                                                    mp_body_airborne_smg
                                                    mp_body_airborne_smg_b
                                                    mp_body_airborne_smg_c
                                                    mp_body_op_airborne_sniper
                                                    mp_body_riot_op_airborne
                                                    mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return SKIDROWBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] SUBBASE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] SUBBASEHead = @"head_allies_seal_udt_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_riot_udt
                                                head_seal_udt_a
                                                head_seal_udt_c
                                                head_seal_udt_d
                                                head_seal_udt_e
                                                head_riot_op_arctic
                                                head_op_arctic_sniper
                                                head_opforce_arctic_a
                                                head_opforce_arctic_b
                                                head_opforce_arctic_c
                                                head_opforce_arctic_d
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return SUBBASEHead;
                    }
                case "body":
                    {
                        string[] SUBBASEBody = @"mp_body_seal_udt_assault_a
                                                mp_body_seal_udt_assault_b
                                                mp_body_seal_udt_sniper
                                                mp_body_riot_udt
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_seal_udt_lmg
                                                mp_body_seal_udt_smg
                                                mp_body_opforce_arctic_lmg
                                                mp_body_opforce_arctic_lmg_b
                                                mp_body_opforce_arctic_lmg_c
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_riot_op_arctic
                                                mp_body_opforce_arctic_assault_a
                                                mp_body_opforce_arctic_assault_b
                                                mp_body_opforce_arctic_assault_c
                                                mp_body_opforce_arctic_smg
                                                mp_body_opforce_arctic_smg_b
                                                mp_body_opforce_arctic_smg_c
                                                mp_body_op_arctic_sniper
                                                mp_body_opforce_arctic_shotgun
                                                mp_body_opforce_arctic_shotgun_b
                                                mp_body_opforce_arctic_shotgun_c".Replace(" ", string.Empty).Split('\n');
                        return SUBBASEBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] TERMINAL(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] TERMINALHead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_f
                                                head_us_army_e
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return TERMINALHead;
                    }
                case "body":
                    {
                        string[] TERMINALBody = @"mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_assault_a
                                                mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_us_army_smg
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_us_army_lmg
                                                mp_body_us_army_riot
                                                mp_body_army_sniper
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return TERMINALBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] UNDERPASS(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] UNDERPASSHead = @"head_militia_ba_blk
                                                head_militia_bb_blk_hat
                                                head_militia_bc_blk
                                                head_militia_bd_blk
                                                head_militia_a_wht
                                                head_riot_op_militia
                                                head_op_militia_sniper
                                                head_op_sniper_ghillie_forest
                                                head_tf141_forest_a
                                                head_tf141_forest_b
                                                head_tf141_forest_c
                                                head_tf141_forest_d
                                                head_allies_tf141_forest_sniper
                                                head_riot_tf141_forest
                                                head_allies_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return UNDERPASSHead;
                    }
                case "body":
                    {
                        string[] UNDERPASSBody = @"mp_body_militia_assault_aa_blk
                                                mp_body_militia_assault_aa_wht
                                                mp_body_militia_assault_ab_blk
                                                mp_body_militia_assault_ac_blk
                                                mp_body_militia_lmg_aa_blk
                                                mp_body_militia_lmg_ab_blk
                                                mp_body_militia_lmg_ac_blk
                                                mp_body_militia_smg_aa_blk
                                                mp_body_militia_smg_aa_wht
                                                mp_body_militia_smg_ab_blk
                                                mp_body_militia_smg_ac_blk
                                                mp_body_op_miltia_sniper
                                                mp_body_riot_op_militia
                                                mp_body_op_sniper_ghillie_forest
                                                mp_body_forest_tf141_assault_a
                                                mp_body_forest_tf141_assault_b
                                                mp_body_forest_tf141_lmg
                                                mp_body_forest_tf141_smg
                                                mp_body_forest_tf141_shotgun
                                                mp_body_tf141_forest_sniper
                                                mp_body_riot_tf141_forest
                                                mp_body_ally_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return UNDERPASSBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] BRECOURT(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] BRECOURTHead = @"head_tf141_forest_a
                                                head_tf141_forest_b
                                                head_tf141_forest_c
                                                head_tf141_forest_d
                                                head_allies_tf141_forest_sniper
                                                head_riot_tf141_forest
                                                head_allies_sniper_ghillie_forest
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return BRECOURTHead;
                    }
                case "body":
                    {
                        string[] BRECOURTBody = @"mp_body_forest_tf141_assault_a
                                                mp_body_forest_tf141_assault_b
                                                mp_body_forest_tf141_lmg
                                                mp_body_forest_tf141_smg
                                                mp_body_forest_tf141_shotgun
                                                mp_body_tf141_forest_sniper
                                                mp_body_riot_tf141_forest
                                                mp_body_ally_sniper_ghillie_forest
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne
                                                mp_body_op_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return BRECOURTBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] WASTELAND(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] WASTELANDHead = @"head_tf141_forest_a
                                                head_tf141_forest_b
                                                head_tf141_forest_c
                                                head_tf141_forest_d
                                                head_allies_tf141_forest_sniper
                                                head_riot_tf141_forest
                                                head_allies_sniper_ghillie_forest
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return WASTELANDHead;
                    }
                case "body":
                    {
                        string[] WASTELANDBody = @"mp_body_forest_tf141_assault_a
                                                mp_body_forest_tf141_assault_b
                                                mp_body_forest_tf141_lmg
                                                mp_body_forest_tf141_smg
                                                mp_body_forest_tf141_shotgun
                                                mp_body_tf141_forest_sniper
                                                mp_body_riot_tf141_forest
                                                mp_body_ally_sniper_ghillie_forest
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne
                                                mp_body_op_sniper_ghillie_forest".Replace(" ", string.Empty).Split('\n');
                        return WASTELANDBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] COMPLEX(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] COMPLEXHead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_e
                                                head_us_army_f
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_riot_op_airborne
                                                head_op_airborne_sniper
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return COMPLEXHead;
                    }
                case "body":
                    {
                        string[] COMPLEXBody = @"mp_body_us_army_assault_a
                                                mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_us_army_lmg
                                                mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_smg
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_army_sniper
                                                mp_body_us_army_riot
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_op_airborne_sniper
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_airborne_lmg
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return COMPLEXBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] BAILOUT(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] BAILOUTHead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_e
                                                head_us_army_f
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_riot_op_airborne
                                                head_op_airborne_sniper
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return BAILOUTHead;
                    }
                case "body":
                    {
                        string[] BAILOUTBody = @"mp_body_us_army_assault_a
                                                mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_us_army_lmg
                                                mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_smg
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_army_sniper
                                                mp_body_us_army_riot
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_op_airborne_sniper
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_airborne_lmg
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return BAILOUTBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] CRASH(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] CRASHHead = @"head_tf141_desert_a
                                            head_tf141_desert_b
                                            head_tf141_desert_c
                                            head_tf141_desert_d
                                            head_allies_tf141_desert_sniper
                                            head_riot_tf141_desert
                                            head_allies_sniper_ghillie_urban
                                            head_opforce_arab_a
                                            head_opforce_arab_b
                                            head_opforce_arab_c
                                            head_opforce_arab_e
                                            head_opforce_arab_d_hat
                                            head_op_sniper_ghillie_urban
                                            head_op_arab_sniper
                                            head_riot_op_arab".Replace(" ", string.Empty).Split('\n');
                        return CRASHHead;
                    }
                case "body":
                    {
                        string[] CRASHBody = @"mp_body_desert_tf141_assault_a
                                            mp_body_desert_tf141_assault_b
                                            mp_body_desert_tf141_lmg
                                            mp_body_desert_tf141_shotgun
                                            mp_body_desert_tf141_smg
                                            mp_body_riot_tf141_desert
                                            mp_body_ally_sniper_ghillie_urban
                                            mp_body_tf141_desert_sniper
                                            mp_body_opforce_arab_assault_a
                                            mp_body_opforce_arab_shotgun_a
                                            mp_body_op_sniper_ghillie_urban
                                            mp_body_opforce_arab_lmg_a
                                            mp_body_riot_op_arab
                                            mp_body_opforce_arab_smg_a
                                            mp_body_op_arab_sniper".Replace(" ", string.Empty).Split('\n');
                        return CRASHBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] OVERGROWN(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] OVERGROWNHead = @"head_tf141_forest_a
                                                head_tf141_forest_b
                                                head_tf141_forest_c
                                                head_tf141_forest_d
                                                head_riot_tf141_forest
                                                head_allies_tf141_forest_sniper
                                                head_allies_sniper_ghillie_forest
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_forest
                                                head_op_airborne_sniper".Replace(" ", string.Empty).Split('\n');
                        return OVERGROWNHead;
                    }
                case "body":
                    {
                        string[] OVERGROWNBody = @"mp_body_forest_tf141_smg
                                                mp_body_forest_tf141_smg
                                                mp_body_riot_tf141_forest
                                                mp_body_forest_tf141_lmg
                                                mp_body_ally_sniper_ghillie_forest
                                                mp_body_forest_tf141_shotgun
                                                mp_body_tf141_forest_sniper
                                                mp_body_forest_tf141_assault_a
                                                mp_body_forest_tf141_assault_b
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_riot_op_airborne
                                                mp_body_airborne_smg
                                                mp_body_op_sniper_ghillie_forest
                                                mp_body_op_airborne_sniper
                                                mp_body_op_airborne_sniper
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c".Replace(" ", string.Empty).Split('\n');
                        return OVERGROWNBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] COMPACT(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] COMPACTHead = @"head_tf141_arctic_a
                                                head_tf141_arctic_b
                                                head_tf141_arctic_c
                                                head_tf141_arctic_d
                                                head_allies_tf141_arctic_sniper
                                                head_allies_sniper_ghillie_arctic
                                                head_allies_sniper_ghillie_urban
                                                head_riot_tf141_arctic
                                                head_opforce_arctic_a
                                                head_opforce_arctic_b
                                                head_opforce_arctic_c
                                                head_opforce_arctic_d
                                                head_op_sniper_ghillie_urban
                                                head_op_sniper_ghillie_arctic
                                                head_op_arctic_sniper
                                                head_riot_op_arctic".Replace(" ", string.Empty).Split('\n');
                        return COMPACTHead;
                    }
                case "body":
                    {
                        string[] COMPACTBody = @"mp_body_tf141_assault_a
                                                mp_body_tf141_assault_b
                                                mp_body_tf141_shotgun
                                                mp_body_tf141_smg
                                                mp_body_tf141_lmg
                                                mp_body_tf141_arctic_sniper
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_ally_sniper_ghillie_arctic
                                                mp_body_riot_tf141_arctic
                                                mp_body_opforce_arctic_assault_a
                                                mp_body_opforce_arctic_assault_b
                                                mp_body_opforce_arctic_assault_c
                                                mp_body_opforce_arctic_lmg
                                                mp_body_opforce_arctic_lmg_b
                                                mp_body_opforce_arctic_lmg_c
                                                mp_body_op_sniper_ghillie_urban
                                                mp_body_riot_op_arctic
                                                mp_body_opforce_arctic_smg
                                                mp_body_opforce_arctic_smg_b
                                                mp_body_opforce_arctic_smg_c
                                                mp_body_op_sniper_ghillie_arctic
                                                mp_body_op_arctic_sniper
                                                mp_body_opforce_arctic_shotgun
                                                mp_body_opforce_arctic_shotgun_b
                                                mp_body_opforce_arctic_shotgun_c".Replace(" ", string.Empty).Split('\n');
                        return COMPACTBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] SALVAGE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] SALVAGEHead = @"head_tf141_arctic_a
                                                head_tf141_arctic_b
                                                head_tf141_arctic_c
                                                head_tf141_arctic_d
                                                head_allies_tf141_arctic_sniper
                                                head_allies_sniper_ghillie_arctic
                                                head_allies_sniper_ghillie_urban
                                                head_riot_tf141_arctic
                                                head_opforce_arctic_a
                                                head_opforce_arctic_b
                                                head_opforce_arctic_c
                                                head_opforce_arctic_d
                                                head_op_sniper_ghillie_urban
                                                head_op_sniper_ghillie_arctic
                                                head_op_arctic_sniper
                                                head_riot_op_arctic".Replace(" ", string.Empty).Split('\n');
                        return SALVAGEHead;
                    }
                case "body":
                    {
                        string[] SALVAGEBody = @"mp_body_tf141_assault_a
                                                mp_body_tf141_assault_b
                                                mp_body_tf141_shotgun
                                                mp_body_tf141_smg
                                                mp_body_tf141_lmg
                                                mp_body_tf141_arctic_sniper
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_ally_sniper_ghillie_arctic
                                                mp_body_riot_tf141_arctic
                                                mp_body_opforce_arctic_assault_a
                                                mp_body_opforce_arctic_assault_b
                                                mp_body_opforce_arctic_assault_c
                                                mp_body_opforce_arctic_lmg
                                                mp_body_opforce_arctic_lmg_b
                                                mp_body_opforce_arctic_lmg_c
                                                mp_body_op_sniper_ghillie_urban
                                                mp_body_riot_op_arctic
                                                mp_body_opforce_arctic_smg
                                                mp_body_opforce_arctic_smg_b
                                                mp_body_opforce_arctic_smg_c
                                                mp_body_op_sniper_ghillie_arctic
                                                mp_body_op_arctic_sniper
                                                mp_body_opforce_arctic_shotgun
                                                mp_body_opforce_arctic_shotgun_b
                                                mp_body_opforce_arctic_shotgun_c".Replace(" ", string.Empty).Split('\n');
                        return SALVAGEBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] STORM(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] STORMHead = @"head_tf141_desert_a
                                            head_tf141_desert_b
                                            head_tf141_desert_c
                                            head_tf141_desert_d
                                            head_allies_tf141_desert_sniper
                                            head_allies_sniper_ghillie_urban
                                            head_riot_tf141_desert
                                            head_airborne_a
                                            head_airborne_b
                                            head_airborne_c
                                            head_airborne_d
                                            head_airborne_e
                                            head_op_airborne_sniper
                                            head_op_sniper_ghillie_urban
                                            head_riot_op_airborne".Replace(" ", string.Empty).Split('\n');
                        return STORMHead;
                    }
                case "body":
                    {
                        string[] STORMBody = @"mp_body_desert_tf141_assault_a
                                            mp_body_desert_tf141_assault_b
                                            mp_body_desert_tf141_smg
                                            mp_body_desert_tf141_shotgun
                                            mp_body_desert_tf141_lmg
                                            mp_body_riot_tf141_desert
                                            mp_body_ally_sniper_ghillie_urban
                                            mp_body_tf141_desert_sniper
                                            mp_body_airborne_assault_a
                                            mp_body_airborne_assault_b
                                            mp_body_airborne_assault_c
                                            mp_body_airborne_smg
                                            mp_body_airborne_smg_b
                                            mp_body_airborne_smg_c
                                            mp_body_op_airborne_sniper
                                            mp_body_op_sniper_ghillie_urban
                                            mp_body_airborne_shotgun
                                            mp_body_airborne_shotgun_b
                                            mp_body_airborne_shotgun_c
                                            mp_body_airborne_lmg
                                            mp_body_airborne_lmg_b
                                            mp_body_airborne_lmg_c
                                            mp_body_riot_op_airborne".Replace(" ", string.Empty).Split('\n');
                        return STORMBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] ABANDON(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] ABANDONHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_riot_tf141_desert
                                                head_allies_tf141_desert_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_militia_bc_blk
                                                head_militia_ba_blk
                                                head_riot_op_militia
                                                head_militia_bb_blk_hat
                                                head_op_militia_sniper
                                                head_op_sniper_ghillie_urban
                                                head_militia_a_wht
                                                head_militia_bd_blk".Replace(" ", string.Empty).Split('\n');
                        return ABANDONHead;
                    }
                case "body":
                    {
                        string[] ABANDONBody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_tf141_desert_sniper
                                                mp_body_militia_smg_aa_blk
                                                mp_body_militia_smg_ab_blk
                                                mp_body_militia_smg_ac_blk
                                                mp_body_op_sniper_ghillie_urban
                                                mp_body_militia_assault_ac_blk
                                                mp_body_militia_lmg_ac_blk
                                                mp_body_op_miltia_sniper
                                                mp_body_militia_assault_ab_blk
                                                mp_body_militia_lmg_aa_blk
                                                mp_body_militia_lmg_ab_blk
                                                mp_body_militia_assault_aa_blk
                                                mp_body_riot_op_militia
                                                mp_body_militia_smg_aa_wht
                                                mp_body_militia_assault_aa_wht".Replace(" ", string.Empty).Split('\n');
                        return ABANDONBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] CARNIVAL(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] CARNIVALHead = @"head_tf141_desert_a
                                                head_tf141_desert_b
                                                head_tf141_desert_c
                                                head_tf141_desert_d
                                                head_riot_tf141_desert
                                                head_allies_tf141_desert_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_militia_bc_blk
                                                head_militia_ba_blk
                                                head_riot_op_militia
                                                head_militia_bb_blk_hat
                                                head_op_militia_sniper
                                                head_op_sniper_ghillie_urban
                                                head_militia_a_wht
                                                head_militia_bd_blk".Replace(" ", string.Empty).Split('\n');
                        return CARNIVALHead;
                    }
                case "body":
                    {
                        string[] CARNIVALBody = @"mp_body_desert_tf141_assault_a
                                                mp_body_desert_tf141_assault_b
                                                mp_body_desert_tf141_smg
                                                mp_body_desert_tf141_lmg
                                                mp_body_desert_tf141_shotgun
                                                mp_body_riot_tf141_desert
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_tf141_desert_sniper
                                                mp_body_militia_smg_aa_blk
                                                mp_body_militia_smg_ab_blk
                                                mp_body_militia_smg_ac_blk
                                                mp_body_op_sniper_ghillie_urban
                                                mp_body_militia_assault_ac_blk
                                                mp_body_militia_lmg_ac_blk
                                                mp_body_op_miltia_sniper
                                                mp_body_militia_assault_ab_blk
                                                mp_body_militia_lmg_aa_blk
                                                mp_body_militia_lmg_ab_blk
                                                mp_body_militia_assault_aa_blk
                                                mp_body_riot_op_militia
                                                mp_body_militia_smg_aa_wht
                                                mp_body_militia_assault_aa_wht".Replace(" ", string.Empty).Split('\n');
                        return CARNIVALBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] FUEL2(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] FUEL2Head = @"head_us_army_a
                                            head_us_army_b
                                            head_us_army_c
                                            head_us_army_d
                                            head_us_army_e
                                            head_us_army_f
                                            head_allies_us_army_sniper
                                            head_allies_sniper_ghillie_desert
                                            head_op_arab_sniper
                                            head_opforce_arab_a
                                            head_opforce_arab_b
                                            head_opforce_arab_c
                                            head_opforce_arab_e
                                            head_opforce_arab_d_hat".Replace(" ", string.Empty).Split('\n');
                        return FUEL2Head;
                    }
                case "body":
                    {
                        string[] FUEL2Body = @"mp_body_us_army_smg
                                            mp_body_us_army_lmg_b
                                            mp_body_us_army_lmg_c
                                            mp_body_us_army_riot
                                            mp_body_us_army_assault_a
                                            mp_body_us_army_assault_b
                                            mp_body_us_army_assault_c
                                            mp_body_army_sniper
                                            mp_body_ally_sniper_ghillie_desert
                                            mp_body_opforce_arab_smg_a
                                            mp_body_opforce_arab_assault_a
                                            mp_body_opforce_arab_lmg_a
                                            mp_body_op_sniper_ghillie_desert
                                            mp_body_op_arab_sniper
                                            mp_body_op_sniper_ghillie_desert 
                                            head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return FUEL2Body;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] FUEL(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] FUELHead = @"head_us_army_a
                                            head_us_army_b
                                            head_us_army_c
                                            head_us_army_d
                                            head_us_army_e
                                            head_us_army_f
                                            head_allies_us_army_sniper
                                            head_allies_sniper_ghillie_desert
                                            head_op_arab_sniper
                                            head_opforce_arab_a
                                            head_opforce_arab_b
                                            head_opforce_arab_c
                                            head_opforce_arab_e
                                            head_opforce_arab_d_hat".Replace(" ", string.Empty).Split('\n');
                        return FUELHead;
                    }
                case "body":
                    {
                        string[] FUELBody = @"mp_body_us_army_smg
                                            mp_body_us_army_lmg_b
                                            mp_body_us_army_lmg_c
                                            mp_body_us_army_riot
                                            mp_body_us_army_assault_a
                                            mp_body_us_army_assault_b
                                            mp_body_us_army_assault_c
                                            mp_body_army_sniper
                                            mp_body_ally_sniper_ghillie_desert
                                            mp_body_opforce_arab_smg_a
                                            mp_body_opforce_arab_assault_a
                                            mp_body_opforce_arab_lmg_a
                                            mp_body_op_sniper_ghillie_desert
                                            mp_body_op_arab_sniper
                                            mp_body_op_sniper_ghillie_desert 
                                            head_op_sniper_ghillie_desert".Replace(" ", string.Empty).Split('\n');
                        return FUELBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] STRIKE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] STRIKEHead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_e
                                                head_us_army_f
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_desert
                                                head_opforce_arab_a
                                                head_opforce_arab_b
                                                head_opforce_arab_c
                                                head_opforce_arab_e
                                                head_opforce_arab_d_hat
                                                head_op_arab_sniper
                                                head_op_sniper_ghillie_desert
                                                head_riot_op_arab".Replace(" ", string.Empty).Split('\n');
                        return STRIKEHead;
                    }
                case "body":
                    {
                        string[] STRIKEBody = @"mp_body_us_army_assault_a
                                                mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_us_army_lmg
                                                mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_ally_sniper_ghillie_desert
                                                mp_body_us_army_riot
                                                mp_body_army_sniper
                                                mp_body_us_army_smg
                                                mp_body_op_arab_sniper
                                                mp_body_opforce_arab_lmg_a
                                                mp_body_op_sniper_ghillie_desert
                                                mp_body_opforce_arab_assault_a
                                                mp_body_opforce_arab_smg_a
                                                mp_body_riot_op_arab
                                                mp_body_opforce_arab_shotgun_a".Replace(" ", string.Empty).Split('\n');
                        return STRIKEBody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] TRAILERPARK(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] TRAILERPARK = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_e
                                                head_us_army_fmp_body_us_army_assault_a
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_urban
                                                head_opforce_arab_a
                                                head_opforce_arab_b
                                                head_opforce_arab_c
                                                head_opforce_arab_e
                                                head_riot_op_arab
                                                head_op_arab_sniper
                                                head_op_sniper_ghillie_urban
                                                head_opforce_arab_d_hat".Replace(" ", string.Empty).Split('\n');
                        return TRAILERPARK;
                    }
                case "body":
                    {
                        string[] TRAILERPARK = @"mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_opforce_arab_lmg_a
                                                mp_body_us_army_lmg
                                                mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_smg
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_army_sniper
                                                mp_body_us_army_riot
                                                mp_body_ally_sniper_ghillie_urban
                                                mp_body_opforce_arab_shotgun_a
                                                mp_body_riot_op_arab
                                                mp_body_op_sniper_ghillie_urban
                                                mp_body_opforce_arab_smg_a
                                                mp_body_opforce_arab_assault_a
                                                mp_body_op_arab_sniper".Replace(" ", string.Empty).Split('\n');
                        return TRAILERPARK;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] VACANT(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] VACANThead = @"head_us_army_a
                                            head_us_army_b
                                            head_us_army_c
                                            head_us_army_d
                                            head_us_army_e
                                            head_us_army_f
                                            head_allies_sniper_ghillie_urban
                                            head_allies_us_army_sniper
                                            head_airborne_a
                                            head_airborne_b
                                            head_airborne_c
                                            head_airborne_d
                                            head_airborne_e
                                            head_riot_op_airborne
                                            head_op_sniper_ghillie_urban
                                            head_op_airborne_sniper".Replace(" ", string.Empty).Split('\n');
                        return VACANThead;
                    }
                case "body":
                    {
                        string[] VACANTbody = @"mp_body_us_army_assault_a
                                            mp_body_us_army_assault_b
                                            mp_body_us_army_assault_c
                                            mp_body_us_army_lmg
                                            mp_body_us_army_lmg_b
                                            mp_body_us_army_lmg_c
                                            mp_body_us_army_smg
                                            mp_body_us_army_smg_b
                                            mp_body_us_army_smg_c
                                            mp_body_army_sniper
                                            mp_body_us_army_riot
                                            mp_body_us_army_shotgun
                                            mp_body_us_army_shotgun_b
                                            mp_body_us_army_shotgun_c
                                            mp_body_ally_sniper_ghillie_urban
                                            mp_body_airborne_lmg
                                            mp_body_airborne_lmg_b
                                            mp_body_airborne_lmg_c
                                            mp_body_airborne_smg_b
                                            mp_body_airborne_smg_c
                                            mp_body_airborne_assault_a
                                            mp_body_airborne_assault_b
                                            mp_body_airborne_assault_c
                                            mp_body_op_airborne_sniper
                                            mp_body_op_sniper_ghillie_urban
                                            mp_body_airborne_shotgun
                                            mp_body_airborne_shotgun_b
                                            mp_body_airborne_shotgun_c
                                            mp_body_riot_op_airborne
                                            mp_body_airborne_smg".Replace(" ", string.Empty).Split('\n');
                        return VACANTbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }

        // START OF UNDOS DUMP LIST, MIGHT NOT BE 100% ACCURATE
        public static string[] NUKETOWN(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] NUKETOWNhead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_f
                                                head_us_army_e
                                                head_allies_us_army_sniper
                                                head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne".Replace(" ", string.Empty).Split('\n');
                        return NUKETOWNhead;
                    }
                case "body":
                    {
                        string[] NUKETOWNbody = @"mp_body_us_army_lmg_b
                                                mp_body_us_army_lmg_c
                                                mp_body_us_army_assault_a
                                                mp_body_us_army_assault_b
                                                mp_body_us_army_assault_c
                                                mp_body_us_army_shotgun
                                                mp_body_us_army_shotgun_b
                                                mp_body_us_army_shotgun_c
                                                mp_body_us_army_smg
                                                mp_body_us_army_smg_b
                                                mp_body_us_army_smg_c
                                                mp_body_us_army_lmg
                                                mp_body_us_army_riot
                                                mp_body_army_sniper
                                                mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne".Replace(" ", string.Empty).Split('\n');
                        return NUKETOWNbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] BLOC(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] BLOChead = @"head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne".Replace(" ", string.Empty).Split('\n');
                        return BLOChead;
                    }
                case "body":
                    {
                        string[] BLOCbody = @"mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne".Replace(" ", string.Empty).Split('\n');
                        return BLOCbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] CROSSFIRE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] CROSShead = @"head_us_army_a
                                                head_us_army_b
                                                head_us_army_c
                                                head_us_army_d
                                                head_us_army_f
                                                head_us_army_e
                                                head_allies_us_army_sniper
                                                head_allies_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CROSShead;
                    }
                case "body":
                    {
                        string[] CROSSbody = @"mp_body_us_army_lmg_b
                                            mp_body_us_army_lmg_c
                                            mp_body_us_army_assault_a
                                            mp_body_us_army_assault_b
                                            mp_body_us_army_assault_c
                                            mp_body_us_army_shotgun
                                            mp_body_us_army_shotgun_b
                                            mp_body_us_army_shotgun_c
                                            mp_body_us_army_smg
                                            mp_body_us_army_smg_b
                                            mp_body_us_army_smg_c
                                            mp_body_us_army_lmg
                                            mp_body_us_army_riot
                                            mp_body_army_sniper
                                            mp_body_ally_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CROSSbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] KILLHOUSE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] killhead = @"head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return killhead;
                    }
                case "body":
                    {
                        string[] killbody = @"mp_body_airborne_assault_a
                                            mp_body_airborne_assault_b
                                            mp_body_airborne_assault_c
                                            mp_body_airborne_lmg
                                            mp_body_airborne_lmg_b
                                            mp_body_airborne_lmg_c
                                            mp_body_airborne_shotgun
                                            mp_body_airborne_shotgun_b
                                            mp_body_airborne_shotgun_c
                                            mp_body_airborne_smg
                                            mp_body_airborne_smg_b
                                            mp_body_airborne_smg_c
                                            mp_body_op_airborne_sniper
                                            mp_body_riot_op_airborne
                                            mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return killbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] CARGOSHIP(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] CARGOhead = @"head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CARGOhead;
                    }
                case "body":
                    {
                        string[] CARGObody = @"mp_body_airborne_assault_a
                                                    mp_body_airborne_assault_b
                                                    mp_body_airborne_assault_c
                                                    mp_body_airborne_lmg
                                                    mp_body_airborne_lmg_b
                                                    mp_body_airborne_lmg_c
                                                    mp_body_airborne_shotgun
                                                    mp_body_airborne_shotgun_b
                                                    mp_body_airborne_shotgun_c
                                                    mp_body_airborne_smg
                                                    mp_body_airborne_smg_b
                                                    mp_body_airborne_smg_c
                                                    mp_body_op_airborne_sniper
                                                    mp_body_riot_op_airborne
                                                    mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CARGObody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] CARGOSHIPSH(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] CARGOSHhead = @"head_tf141_arctic_a
                                                head_tf141_arctic_b
                                                head_tf141_arctic_c
                                                head_tf141_arctic_d
                                                head_allies_tf141_arctic_sniper
                                                head_riot_tf141_arctic
                                                head_allies_sniper_ghillie_arctic
                                                head_opforce_arctic_a
                                                head_opforce_arctic_b
                                                head_opforce_arctic_c
                                                head_opforce_arctic_d
                                                head_op_arctic_sniper
                                                head_riot_op_arctic
                                                head_op_sniper_ghillie_arctic".Replace(" ", string.Empty).Split('\n');
                        return CARGOSHhead;
                    }
                case "body":
                    {
                        string[] CARGOSHbody = @"mp_body_tf141_assault_a
                                                mp_body_tf141_assault_b
                                                mp_body_tf141_lmg
                                                mp_body_tf141_smg
                                                mp_body_tf141_shotgun
                                                mp_body_tf141_arctic_sniper
                                                mp_body_riot_tf141_arctic
                                                mp_body_ally_sniper_ghillie_arctic
                                                mp_body_opforce_arctic_assault_a
                                                mp_body_opforce_arctic_assault_b
                                                mp_body_opforce_arctic_assault_c
                                                mp_body_opforce_arctic_lmg
                                                mp_body_opforce_arctic_lmg_b
                                                mp_body_opforce_arctic_lmg_c
                                                mp_body_opforce_arctic_shotgun
                                                mp_body_opforce_arctic_shotgun_b
                                                mp_body_opforce_arctic_shotgun_c
                                                mp_body_opforce_arctic_smg
                                                mp_body_opforce_arctic_smg_b
                                                mp_body_opforce_arctic_smg_c
                                                mp_body_op_arctic_sniper
                                                mp_body_riot_op_arctic
                                                mp_body_op_sniper_ghillie_arctic".Replace(" ", string.Empty).Split('\n');
                        return CARGOSHbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] SHIPMENT(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] CARGOSHhead = @"head_airborne_a
                                                head_airborne_b
                                                head_airborne_c
                                                head_airborne_d
                                                head_airborne_e
                                                head_op_airborne_sniper
                                                head_riot_op_airborne
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CARGOSHhead;
                    }
                case "body":
                    {
                        string[] CARGOSHbody = @"mp_body_airborne_assault_a
                                                mp_body_airborne_assault_b
                                                mp_body_airborne_assault_c
                                                mp_body_airborne_lmg
                                                mp_body_airborne_lmg_b
                                                mp_body_airborne_lmg_c
                                                mp_body_airborne_shotgun
                                                mp_body_airborne_shotgun_b
                                                mp_body_airborne_shotgun_c
                                                mp_body_airborne_smg
                                                mp_body_airborne_smg_b
                                                mp_body_airborne_smg_c
                                                mp_body_op_airborne_sniper
                                                mp_body_riot_op_airborne
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return CARGOSHbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] FIRINGRANGE(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] FIRINGRANGEhead = @"head_militia_ba_blk
                                                head_militia_bb_blk_hat
                                                head_militia_bc_blk
                                                head_militia_bd_blk
                                                head_militia_a_wht
                                                head_riot_op_militia
                                                head_op_militia_sniper
                                                head_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return FIRINGRANGEhead;
                    }
                case "body":
                    {
                        string[] FIRINGRANGEbody = @"mp_body_militia_assault_aa_blk
                                                mp_body_militia_assault_aa_wht
                                                mp_body_militia_assault_ab_blk
                                                mp_body_militia_assault_ac_blk
                                                mp_body_militia_lmg_aa_blk
                                                mp_body_militia_lmg_ab_blk
                                                mp_body_militia_lmg_ac_blk
                                                mp_body_militia_smg_aa_blk
                                                mp_body_militia_smg_aa_wht
                                                mp_body_militia_smg_ab_blk
                                                mp_body_militia_smg_ac_blk
                                                mp_body_op_miltia_sniper
                                                mp_body_riot_op_militia
                                                mp_body_op_sniper_ghillie_urban".Replace(" ", string.Empty).Split('\n');
                        return FIRINGRANGEbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
        public static string[] OILRIG(string model)
        {
            switch (model)
            {
                case "head":
                    {
                        string[] OILRIGhead = @"head_opforce_arctic_a
                                                head_opforce_arctic_b
                                                head_opforce_arctic_c
                                                head_opforce_arctic_d
                                                head_op_arctic_sniper
                                                head_riot_op_arctic
                                                head_op_sniper_ghillie_arctic".Replace(" ", string.Empty).Split('\n');
                        return OILRIGhead;
                    }
                case "body":
                    {
                        string[] OILRIGbody = @"mp_body_opforce_arctic_assault_a
                                                mp_body_opforce_arctic_assault_b
                                                mp_body_opforce_arctic_assault_c
                                                mp_body_opforce_arctic_lmg
                                                mp_body_opforce_arctic_lmg_b
                                                mp_body_opforce_arctic_lmg_c
                                                mp_body_opforce_arctic_shotgun
                                                mp_body_opforce_arctic_shotgun_b
                                                mp_body_opforce_arctic_shotgun_c
                                                mp_body_opforce_arctic_smg
                                                mp_body_opforce_arctic_smg_b
                                                mp_body_opforce_arctic_smg_c
                                                mp_body_op_arctic_sniper
                                                mp_body_riot_op_arctic
                                                mp_body_op_sniper_ghillie_arctic".Replace(" ", string.Empty).Split('\n');
                        return OILRIGbody;
                    }
                default:
                    {
                        string[] NONE = { "NONE" };
                        return NONE;
                    }
            }
        }
    }
}
