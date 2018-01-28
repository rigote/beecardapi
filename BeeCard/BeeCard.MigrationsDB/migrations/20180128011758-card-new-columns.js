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

    //Personal Card
    db.addColumn('PersonalCard', 'State', { type: 'string', notNull: false, length: 30 }, callback);
    db.addColumn('PersonalCard', 'Bio', { type: 'string', notNull: false, length: 500 }, callback);

    //Skill
    db.createTable('Skill', {
        ID: { type: 'uuid', primaryKey: true },
        Name: { type: 'string', notNull: true, length: 255 },        
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);

    //PersonalCardSkill
    db.createTable('PersonalCardSkill', {
        ID: { type: 'uuid', primaryKey: true },
        PersonalCardID: { type: 'uuid', notNull: true },
        SkillID: { type: 'uuid', notNull: true },
        Status: { type: 'int', notNull: true },
        CreateDate: { type: 'datetime', notNull: true },
        ModifyDate: { type: 'datetime', notNull: false }
    }, callback);
    
};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
