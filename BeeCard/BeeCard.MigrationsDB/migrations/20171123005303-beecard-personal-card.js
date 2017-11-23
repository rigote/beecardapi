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
    db.addColumn('PersonalCard', 'Occupation', { type: 'string', notNull: false, length: 150 }, callback);
    db.addColumn('PersonalCard', 'Photo', { type: 'string', notNull: false, length: 50 }, callback);
};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
