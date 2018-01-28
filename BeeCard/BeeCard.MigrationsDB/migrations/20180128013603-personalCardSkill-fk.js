'use strict';

var dbm;
var type;
var seed;

/**
  * We receive the dbmigrate dependency from dbmigrate initially.
  * This enables us to not have to rely on NODE_PATH.
  */
exports.setup = function(options, seedLink) {
  dbm = options.dbmigrate;
  type = dbm.dataType;
  seed = seedLink;
};

exports.up = function (db, callback) {

    db.addForeignKey('PersonalCardSkill', 'PersonalCard', 'PersonalCardSkill_PersonalCard_FK',
        {
            'PersonalCardID': 'ID'
        },
        {
            onDelete: 'RESTRICT',
            onUpdate: 'RESTRICT'
        }, callback);

    db.addForeignKey('PersonalCardSkill', 'Skill', 'PersonalCardSkill_Skill_FK',
        {
            'SkillID': 'ID'
        },
        {
            onDelete: 'RESTRICT',
            onUpdate: 'RESTRICT'
        }, callback);

};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
