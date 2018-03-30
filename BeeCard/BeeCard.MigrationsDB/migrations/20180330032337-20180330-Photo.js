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
    //User
    db.changeColumn('User', 'Photo', { type: 'text', notNull: false }, callback);   

    //PersonalCard
    db.changeColumn('PersonalCard', 'Photo', { type: 'text', notNull: false }, callback);
};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
