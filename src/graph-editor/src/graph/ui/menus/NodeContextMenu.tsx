import React, {FC} from "react";
import ContextMenu, {ContextMenuProps} from "components/ContextMenu";
import {ListGroup} from "react-bootstrap";
import FormInput from "components/forms/FormInput";

export interface NodeContextMenuProps extends ContextMenuProps {
  onAddLinkClick?: () => void;
  onDeleteNodeClick?: () => void;
  onEditNodeClick?: () => void;
}

const NodeContextMenu: FC<NodeContextMenuProps> =
  React.memo(({onAddLinkClick, onDeleteNodeClick, onEditNodeClick, ...cmProps}) => {

    return (
      <ContextMenu {...cmProps}>
        <ListGroup>
          <ListGroup.Item action onClick={onAddLinkClick}>
            Add link
          </ListGroup.Item>
          <ListGroup.Item action onClick={onDeleteNodeClick}>
            Delete node
          </ListGroup.Item>
          <ListGroup.Item action onClick={onEditNodeClick}>
            Edite node
          </ListGroup.Item>
        </ListGroup>
      </ContextMenu>
    );
  });
NodeContextMenu.displayName = "NodeContextMenu";
export default NodeContextMenu;