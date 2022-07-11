/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// https://ckeditor.com/docs/ckeditor4/latest/api/CKEDITOR_config.html

	// The toolbar groups arrangement, optimized for two toolbar rows.
	config.toolbarGroups = [
		{ name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
		{ name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
		{ name: 'links' },
		{ name: 'insert' },
		{ name: 'forms' },
		{ name: 'font', items: ['Font', 'FontSize'] },
		{ name: 'tools' },
		{ name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
		{ name: 'others' },
		'/',
		{ name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
		{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ] },
		{ name: 'styles' },
		{ name: 'colors' },
		{ name: 'about' }
	];

	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Set the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Simplify the dialog windows.
	config.removeDialogTabs = 'image:advanced;link:advanced';

	config.fontSize = {
		items: [
			'tiny',
			'small',
			'normal',
			'big',
			'huge'
		]
	}

	// Using presets (px values):
	config.fontSize = {
		items: [
			10,
			12,
			'normal',
			16,
			20
		]
	}

	// Using full flavor:
	config.fontSize = {
		items: [
			{
				label: 'Tiny',
				// Used as attribute name:
				model: 'text-tiny',
				stopValue: 10,
				// Uses the ViewElementConfigDefinition interface:
				view: {
					name: 'span',
					classes: 'text-tiny'
				}
			},

			{
				label: 'Small',
				model: 'text-small',
				stopValue: 12,
				view: {
					name: 'span',
					classes: 'text-small'
				}
			},

			// etc...
		]
	}

	

};
