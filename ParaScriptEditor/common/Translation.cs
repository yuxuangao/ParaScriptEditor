using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaScriptEditor
{
    internal class Translation
    {
        public static readonly Dictionary<string, string> logicCommandMap = new()
        {
            { "AND", "满足以下全部条件" },
            { "OR", "满足以下任一条件" },
            { "NOT", "不满足以下条件" },
            { "NAND", "不满足以下任一条件" },
        };

        public static readonly Dictionary<string, Key> triggerMap = new()
        {
            { "adventurer", new Key("adventurer", "是冒险者", Scope.title, ValueType.boolean, Category.titles) },
            { "age", new Key("age", "年龄", Scope.character, ValueType.intValue, Category.characters) },
            { "ai", new Key("ai", "是AI", Scope.character, ValueType.boolean, Category.characters) },
            { "always", new Key("always", "总是", Scope.any, ValueType.boolean, Category.control) },
            { "artifact", new Key("artifact", "指定宝物", Scope.artifact, ValueType.artifact, Category.control) },
            { "artifact_age", new Key("artifact_age", "宝物年龄", Scope.artifact, ValueType.intValue, Category.control) },
            { "artifact_type", new Key("artifact_type", "宝物类型", Scope.artifact, ValueType.artifactType, Category.artifacts) },
            { "artifact_type_owned_by", new Key("artifact_type_owned_by", "指定角色拥有此类型宝物", Scope.artifact, ValueType.character, Category.artifacts) },
            { "attribute_diff", new Key("attribute_diff", "同指定角色指定属性的差", Scope.character, ValueType.clause, Category.characters) },
            { "at_location", new Key("at_location", "角色所在地", Scope.character, new ValueType[] { ValueType.character, ValueType.province, ValueType.title }, Category.provinces) },
            { "base_health", new Key("base_health", "基础健康", Scope.character, ValueType.doubleValue, Category.health) },
            { "borders_lake", new Key("borders_lake", "省份临湖", Scope.province, ValueType.boolean, Category.provinces) },
            { "borders_major_river", new Key("borders_major_river", "省份临大河", Scope.province, ValueType.boolean, Category.provinces) },
            { "calc_true_if", new Key("calc_true_if", "符合的条件满足指定数量", Scope.any, ValueType.clause, Category.control) },
            { "can_be_given_away", new Key("can_be_given_away", "头衔可以被授予", Scope.title, ValueType.boolean, Category.titles) },
            { "can_change_religion", new Key("can_change_religion", "可以改变宗教", Scope.character, ValueType.boolean, Category.religion) },
            { "can_call_crusade", new Key("can_call_crusade", "可以号召大圣战", Scope.character, ValueType.boolean, Category.religion) },
            { "can_grant_title", new Key("can_grant_title", "可以授予指定荣誉称号", Scope.character, ValueType.minorTitle, Category.rulers) },
            { "can_land_path_to", new Key("can_land_path_to", "两地陆路可通", Scope.province, new ValueType[] { ValueType.province, ValueType.clause }, Category.provinces) },
            { "can_naval_path_to", new Key("can_naval_path_to", "两地水路可通", Scope.province, new ValueType[] { ValueType.province, ValueType.clause }, Category.provinces) },
            { "can_hold_title", new Key("can_hold_title", "检查指定内阁位置或荣誉头衔条件", Scope.character, new ValueType[] { ValueType.jobTitle, ValueType.minorTitle }, Category.characters) },
            { "can_join_society", new Key("can_join_society", "可以参加指定社团", Scope.character, ValueType.society, Category.societies) },
            { "can_marry", new Key("can_marry", "可以结婚", Scope.character, new ValueType[] { ValueType.boolean, ValueType.character }, Category.marriage) },
            { "can_swap_job_title", new Key("can_swap_job_title", "可以从另一人处得到内阁席位", Scope.character, ValueType.character, Category.characters) },
            { "can_use_cb", new Key("can_use_cb", "可以使用宣战理由", Scope.character, ValueType.clause, Category.wars) },
            { "target", new Key("target", "控制目标", Scope.any, ValueType.any, Category.control) },
            { "casus_belli", new Key("casus_belli", "使用的宣战理由", Scope.character, ValueType.cb, Category.wars) },
            { "thirdparty_title", new Key("thirdparty_title", "目标头衔", Scope.character, ValueType.title, Category.wars) },
            { "thirdparty", new Key("thirdparty", "替代的发动战争者", Scope.character, ValueType.character, Category.wars) },
            { "only_check_triggers", new Key("only_check_triggers", "仅检查触发器", Scope.character, ValueType.boolean, Category.wars) },
            { "character", new Key("character", "检查是否是同一人", Scope.character, new ValueType[] { ValueType.character, ValueType.title, ValueType.intValue }, Category.characters) },
            { "clan", new Key("clan", "是游牧部族首领", new Scope[] { Scope.character, Scope.title }, ValueType.boolean, Category.clans) },
            { "combat_rating", new Key("combat_rating", "角色的个人实战技能", Scope.character, ValueType.intValue, Category.characters) },
            { "combat_rating_diff", new Key("combat_rating_diff", "同指定角色的个人实战技能差值", Scope.character, ValueType.clause, Category.characters) },
            { "completely_controls_region", new Key("completely_controls_region", "完全控制地区", Scope.character, ValueType.region, Category.rulers) },
            { "controlled_by", new Key("controlled_by", "头衔、省份被另一人控制", new Scope[] { Scope.title, Scope.province }, new ValueType[] { ValueType.character, ValueType.title }, Category.wars) },
            { "controls_religion", new Key("controls_religion", "是宗教控制者", new Scope[] { Scope.character, Scope.title }, ValueType.boolean, Category.religion) },
            { "could_be_parent_of", new Key("could_be_parent_of", "年龄上能成为指定角色的父母", Scope.character, ValueType.character, Category.characters) },
            { "count", new Key("count", "合计", Scope.any, ValueType.intValue, Category.control) },
            { "crusade_preparation_strength", new Key("crusade_preparation_strength", "大圣战准备力量和防御方比值", Scope.any, ValueType.floatValue, Category.wars) },
            { "crusade_preparation_time_remaining", new Key("crusade_preparation_time_remaining", "大圣战准备剩余时间", Scope.any, ValueType.intValue, Category.wars) },
            { "culture", new Key("culture", "是否拥有指定文化", new Scope[] { Scope.character, Scope.province, Scope.title }, new ValueType[] { ValueType.culture, ValueType.character, ValueType.province, ValueType.title }, Category.culture) },
            { "culture_group", new Key("culture_group", "是否拥有指定文化组", new Scope[] { Scope.character, Scope.province, Scope.title }, new ValueType[] { ValueType.cultureGroup, ValueType.character, ValueType.province, ValueType.title }, Category.culture) },
        };

        public static readonly Dictionary<string, Key> commandMap = new()
        {
            { "activate_disease", new Key("activate_disease", "激活疾病", Scope.any, ValueType.disease, Category.health) },
        };

        public static readonly Dictionary<KeyType, string> keyTypeNameMap = new()
        {
            { KeyType.all, "全部" },
            { KeyType.logicCommand, "逻辑条件" },
            { KeyType.trigger, "条件" },
            { KeyType.command, "指令" },
        };
    }
}
