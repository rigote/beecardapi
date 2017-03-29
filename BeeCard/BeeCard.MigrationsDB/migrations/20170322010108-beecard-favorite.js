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
    //Company
    db.addColumn('Company', 'CardIdentityConfig', { type: 'string', notNull: true, length: 1000 }, callback);

    //UserGroup_PersonalCard
    db.addColumn('UserGroup_CorporateCard', 'Blacklist', { type: 'boolean', notNull: false }, callback);
    db.addColumn('UserGroup_CorporateCard', 'Favorite', { type: 'boolean', notNull: false }, callback);

    //UserGroup_PersonalCard
    db.addColumn('UserGroup_PersonalCard', 'Blacklist', { type: 'boolean', notNull: false }, callback);
    db.addColumn('UserGroup_PersonalCard', 'Favorite', { type: 'boolean', notNull: false }, callback);
};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
